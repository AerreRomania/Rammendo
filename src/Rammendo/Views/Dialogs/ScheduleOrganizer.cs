using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Windows.Forms;

namespace Rammendo.Views.Dialogs
{
    public partial class ScheduleOrganizer : Form
    {
        private string Operator { get; set; }
        private string Key { get; set; }
        private int Qty { get; set; }

        private DateTime StartTime { get; set; }
        private DateTime EndTime { get; set; }
        private bool CanManage { get; set; }

        private List<ScheduleControl.Operators> _lstOperators = new List<ScheduleControl.Operators>();

        public ScheduleOrganizer()
        {
            InitializeComponent();
        }

        public ScheduleOrganizer(string name, string key, DateTime startTime, DateTime endTime, int dailyQty = 0, int fixedQty = 0, int prodQty = 0, bool canManage = true)
        {
            InitializeComponent();

            Operator = name;
            Key = key;
            Qty = fixedQty;
            StartTime = startTime;
            EndTime = endTime;
            CanManage = canManage;

            lblOperator.Text = Operator;
            lblNorm.Text = dailyQty.ToString();
            lblTargetQty.Text = fixedQty.ToString();
            lblProdQty.Text = prodQty.ToString();
            lblDiff.Text = (fixedQty - prodQty).ToString();
            lblProgrammedDate.Text = startTime.ToString("dd-MM-yyyy HH:mm") + "  -  " + endTime.ToString("dd-MM-yyyy HH:mm");

            LoadOperators();
            LoadCommessaDetails();
            LoadProductionTable();

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }

            if (!canManage)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                lblAlert.Visible = true;
            }
        }

        private void LoadCommessaDetails()
        {
            var qry = @"
SELECT A.Commessa,A.Article,B.Cantitate,A.QtyPack,A.CreatedDate,A.StartJob FROM RammendoImport A 
LEFT JOIN Comenzi B ON A.Commessa = B.NrComanda AND B.IdSector = 7 AND IsDeleted = 0
WHERE A.Barcode=@Barcode;";

            try
            {
                using (var c = new SqlConnection(Central.CONNECTION_STRING))
                {
                    var cmd = new SqlCommand(qry, c);
                    cmd.Parameters.Add("@Barcode", System.Data.SqlDbType.NVarChar).Value = Key.Split('_')[1];
                    c.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                        while (dr.Read())
                        {
                            lblCommessa.Text = dr[0].ToString();
                            lblArticle.Text = dr[1].ToString();
                            lblQtyPack.Text = dr[3].ToString();
                            DateTime.TryParse(dr[4].ToString(), out var readedDate);
                            DateTime.TryParse(dr[5].ToString(), out var startWork);
                            lblReadedDate.Text = readedDate.ToString("dd-MM-yyyy HH:mm");
                            if (string.IsNullOrEmpty(dr[2].ToString()))
                            {
                                lblTotalQty.Text = "Not linked";
                                lblTotalQty.ForeColor = Color.Crimson;
                            }
                            else
                            {
                                lblTotalQty.Text = dr[2].ToString();
                            }
                            if (string.IsNullOrEmpty(dr[5].ToString()))
                            {
                                lblWorkStart.Text = string.Empty;
                            }
                            else
                            {
                                lblWorkStart.Text = startWork.ToString("dd-MM-yyyy HH:mm");
                            }
                        }
                    c.Close();
                }
            }
            catch (Exception)
            {
            }     
        }

        private void LoadOperators()
        {
            _lstOperators = new List<ScheduleControl.Operators>();
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
                            _lstOperators.Add(new ScheduleControl.Operators(id, dr[1].ToString(), dr[2].ToString()));
                        }
                    c.Close();
                }

                Dictionary<int, string> items = new Dictionary<int, string>();

                foreach (var operat in _lstOperators)
                {
                    if (operat.Operator == Operator) continue;
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

        private void LoadProductionTable()
        {
            var dt = new System.Data.DataTable();

            var qry = @"
SELECT Operator, 
	   MIN(productionDate) AS StartTime, 
	   MAX(productionDate) AS EndTime, 
	   SUM(Qty) AS ProducedQty FROM rammendoproduction 
WHERE Operator=@Operator AND Barcode=@Barcode
GROUP BY operator,barcode, 	
		 CONVERT(NVARCHAR, productionDate, 110)
;";

            try
            {
                using (var c = new SqlConnection(Central.CONNECTION_STRING))
                {
                    var cmd = new SqlCommand(qry, c);
                    cmd.Parameters.Add("@Operator", System.Data.SqlDbType.NVarChar).Value = Operator;
                    cmd.Parameters.Add("@Barcode", System.Data.SqlDbType.NVarChar).Value = Key.Split('_')[1];

                    c.Open();
                    var dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    c.Close();
                }

                DgvCaricoLavoro.DataSource = dt;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!CanManage)
            {
                MessageBox.Show("Cannot delete this task because it has production.");
                return;
            }

            var dialog = MessageBox.Show("Are you sure you want to delete this task?", "Produzione gantt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.No)
            {
                return;
            }

            var qry = "DELETE FROM RammendoSchedule WHERE CONCAT(Id,'_',Barcode) = '" + Key + "'";
            var updateQuery = "UPDATE RammendoImport SET QtyProgram=QtyProgram+@QtyProgram WHERE Barcode=@Barcode";
            var barcode = Key.Split('_')[1];

            try
            {
                var key = Key.Split('_')[1];

                using (var c = new SqlConnection(Central.CONNECTION_STRING))
                {
                    var cmd = new SqlCommand(qry, c);
                    c.Open();
                    var dr = cmd.ExecuteNonQuery();
                    cmd = new SqlCommand(updateQuery, c);
                    cmd.Parameters.Add("@QtyProgram", System.Data.SqlDbType.Int).Value = Qty;
                    cmd.Parameters.Add("@Barcode", System.Data.SqlDbType.NVarChar).Value = barcode;
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (!CanManage)
            {
                MessageBox.Show("Cannot update this task because it has production.");
                return;
            }

            var dialog = MessageBox.Show("Are you sure you want to move this task to " + comboBox1.Text + "?", "Produzione gantt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.No)
            {
                return;
            }

            //get operator definitions
            var operat = comboBox1.Text;
            var key = ((KeyValuePair<int, string>)comboBox1.SelectedItem).Key;
            var line = _lstOperators.Where(x => x.Id == key).FirstOrDefault().Line;

            // move task
            try
            {
                var organizer = new Helpers.ScheduleOrganizer.Organize();
                organizer.MoveTask(dateTimePicker1.Value, StartTime, EndTime, operat, line, Key);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Organizer - Move task", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var operat = comboBox1.Text;
            button2.Text = "Move to " + operat;
        }
    }
}
