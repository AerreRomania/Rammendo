using Rammendo.Helpers;
using System.Drawing;
using System.Windows.Forms;

namespace Rammendo.Controls
{
    public class CGridView : DataGridView
    {
       public CGridView() {
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToOrderColumns = false;
            AllowUserToResizeRows = false;
            AllowUserToResizeColumns = false;
            ReadOnly = true;
            RowHeadersVisible = false;
            BackgroundColor = Color.WhiteSmoke;
            MultiSelect = false;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            EnableHeadersVisualStyles = false;
            ColumnHeadersHeight = 32;
            CellBorderStyle = DataGridViewCellBorderStyle.Single;
            GridColor = Color.Gainsboro;
            ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15, FontStyle.Regular);
            ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;

            DataBindingComplete += (s, e) => {
                if (Columns.Count > 0) {
                    foreach (DataGridViewColumn c in Columns) {
                        c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            };

            this.DoubleBuffered(true);
        } 
    }
}
