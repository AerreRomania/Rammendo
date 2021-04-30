using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Rammendo.Views.Dialogs
{
    public partial class ScheduleOrganizer : Form
    {
        private string Operator { get; set; }
        private string Key { get; set; }
        private int Qty { get; set; }
        private bool CanManage { get; set; }

        private List<ScheduleControl.Operators> _lstOperators = new List<ScheduleControl.Operators>();

        public ScheduleOrganizer()
        {
            InitializeComponent();
        }

        public ScheduleOrganizer(string name, string key,int dailyQty = 0, int fixedQty = 0, int prodQty = 0, bool canManage = true)
        {
            InitializeComponent();

            Operator = name;
            Key = key;
            Qty = fixedQty;
            CanManage = canManage;

            lblOperator.Text = Operator;
            lblNorm.Text = dailyQty.ToString();
            lblTargetQty.Text = fixedQty.ToString();
            lblProdQty.Text = prodQty.ToString();
            lblDiff.Text = (fixedQty - prodQty).ToString();
            
            LoadOperators();
            LoadProductionTable();
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
            var updateQuery = "UPDATE RammendoImport SET QtyProgram=@QtyProgram WHERE Barcode=@Barcode";
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

            var qry = "UPDATE RammendoSchedule SET Operator=@Operator, Line=@Line WHERE CONCAT(Id,'_',Barcode) = '" + Key + "'";

            try
            {
                var operat = comboBox1.Text;
                var key = ((KeyValuePair<int, string>)comboBox1.SelectedItem).Key;
                var line = _lstOperators.Where(x => x.Id == key).FirstOrDefault().Line;

                using (var c = new SqlConnection(Central.CONNECTION_STRING))
                {
                    var cmd = new SqlCommand(qry, c);
                    cmd.Parameters.Add("@Operator", System.Data.SqlDbType.NVarChar).Value = operat;
                    cmd.Parameters.Add("@Line", System.Data.SqlDbType.NVarChar).Value = line;

                    c.Open();
                    var dr = cmd.ExecuteNonQuery();
                    c.Close();
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var operat = comboBox1.Text;
            button2.Text = "Move to " + operat;
        }
    }
}
