using DevExpress.XtraEditors.Controls;
using Rammendo.Behaviors;
using Rammendo.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rammendo.Views.Dialogs
{
    public partial class ScheduleControl : CWindow
    {
        private string Barcode { get; set; }

        private List<Operators> _lstOperators = new List<Operators>();

        public ScheduleControl(string barcode)
        {
            InitializeComponent();

            Barcode = barcode;

            this.DoubleBuffered(true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            pnTitlebar.MouseMove += (s, mv) => {
                if (mv.Button == MouseButtons.Left && WindowState != FormWindowState.Maximized)
                {
                    Resizer.ReleaseCapture();
                    Resizer.SendMessage(Handle, Resizer.WM_NCLBUTTONDOWN, Resizer.HT_CAPTION, 0);
                }
            };
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadOperators();
            GetInfoBybarcode();

            foreach (DataGridViewColumn c in dgvInfo.Columns)
            {
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }
        }

        private void LoadOperators()
        {
            _lstOperators = new List<Operators>();
            var qry = "SELECT CodAngajat, Angajat, Linie FROM Angajati WHERE Mansione='RAMMENDO' AND Active=1";

            try
            {
                using (var c = new SqlConnection(Central.CONNECTION_STRING))
                {
                    var cmd = new SqlCommand(qry, c);
                    c.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                        while (dr.Read())
                        {
                            int.TryParse(dr[0].ToString(), out var id);                          
                            _lstOperators.Add(new Operators(id, dr[1].ToString(), dr[2].ToString()));
                        }
                    c.Close();
                }

                Dictionary<int, string> items = new Dictionary<int, string>();

                foreach (var operat in _lstOperators)
                {
                    items.Add(operat.Id, operat.Operator);
                }
                comboBox1.DataSource = new BindingSource(items, null);
                comboBox1.DisplayMember = "Value";
                comboBox1.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetInfoBybarcode()
        {
            var dt = new DataTable();
            var qry = "SELECT a.*, b.CapiRammendo AS CapiRammendo FROM RammendoImport a " +
                "LEFT JOIN Articole b on a.Article = b.Articol AND b.IdSector = 7" +
                "WHERE Barcode=@Barcode";

            try
            {
                using (var c = new SqlConnection(Central.CONNECTION_STRING))
                {
                    var cmd = new SqlCommand(qry, c);
                    cmd.Parameters.Add("@Barcode", SqlDbType.NVarChar).Value = Barcode;
                    c.Open();
                    var dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    c.Close();
                }

                dgvInfo.DataSource = dt;

                int.TryParse(dgvInfo.Rows[0].Cells[9].Value.ToString(), out var badQty);
                int.TryParse(dgvInfo.Rows[0].Cells[28].Value.ToString(), out var programmedQty);
                double.TryParse(dgvInfo.Rows[0].Cells["CapiRammendo"].Value.ToString(), out var qtyH);

                lblCommessa.Text = "Commessa: " + dgvInfo.Rows[0].Cells[0].Value.ToString();
                lblQtyH.Text = "C/H: " + Math.Round(qtyH, 2).ToString();
                lblMaxQty.Text = "Max qty: " + (badQty - programmedQty).ToString();
                if (qtyH == 0) lblQtyH.ForeColor = Color.Red;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InsertRecord()
        {
            var operat = comboBox1.Text;
            var key = ((KeyValuePair<int, string>)comboBox1.SelectedItem).Key;
            var line = _lstOperators.Where(x => x.Id == key).FirstOrDefault().Line;

            double.TryParse(dgvInfo.Rows[0].Cells["CapiRammendo"].Value.ToString(), out var capiH);
            DateTime.TryParse(dateTimePicker1.Value.ToString(), out var startDate);
            int.TryParse(textBox1.Text, out var insertedQty);
            int.TryParse(dgvInfo.Rows[0].Cells[9].Value.ToString(), out var badQty);
            int.TryParse(dgvInfo.Rows[0].Cells[28].Value.ToString(), out var programmedQty);
            var qtyMax = badQty - programmedQty;

            capiH = 30.5;

            if (capiH == 0)
            {
                MessageBox.Show("Cannot create task with CapiH = 0", "Create task", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (insertedQty > qtyMax)
            {
                MessageBox.Show("inserted qty is greater qty left. Qty left is " + qtyMax.ToString(), "Create task", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var times = Convert.ToDouble(Convert.ToDouble(insertedQty) / capiH);
            var fd = TimeSpan.FromDays(times).Ticks;

            var endDate = startDate.AddTicks(fd);

            var qry = "INSERT INTO RammendoSchedule (Operator,Barcode,StartTime,EndTime,ProductionStartTime,ProductionEndTime,DelayStartTime,DelayEndTime,Qty,CapiH,Line) " +
                "VALUES (@p1,@p2,@p3,@p4,null,null,null,null,@p9,@p10,@p11)";

            var updateQuery = "UPDATE RammendoImport SET QtyProgram=@QtyProgram WHERE Barcode=@Barcode";
            try
            {
                using (var c = new SqlConnection(Central.CONNECTION_STRING))
                {
                    c.Open();
                    var cmd = new SqlCommand(qry, c);
                    cmd.Parameters.Add("@p1", SqlDbType.NVarChar).Value = operat;
                    cmd.Parameters.Add("@p2", SqlDbType.NVarChar).Value = Barcode;
                    cmd.Parameters.Add("@p3", SqlDbType.DateTime).Value = startDate;
                    cmd.Parameters.Add("@p4", SqlDbType.DateTime).Value = endDate;
                    cmd.Parameters.Add("@p9", SqlDbType.Int).Value = insertedQty;
                    cmd.Parameters.Add("@p10", SqlDbType.Float).Value = capiH;
                    cmd.Parameters.Add("@p11", SqlDbType.NVarChar).Value = line;
                    var dr = cmd.ExecuteNonQuery();
                    cmd = new SqlCommand(updateQuery, c);
                    cmd.Parameters.Add("@QtyProgram", SqlDbType.Int).Value = insertedQty;
                    cmd.Parameters.Add("@Barcode", SqlDbType.NVarChar).Value = Barcode;
                    var dr1 = cmd.ExecuteNonQuery(); 
                    c.Close();
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal class Operators
        {
            public int Id { get; set; }
            public string Operator { get; set; }
            public string Line { get; set; }

            public Operators(int id, string operat, string line)
            {
                Id = id;
                Operator = operat;
                Line = line;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            InsertRecord();
        }
    }
}
