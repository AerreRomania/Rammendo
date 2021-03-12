using System;
using System.Data;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rammendo.ViewModels
{
    public class TelliProdotiPersoneViewModel
    {
        public Task<DataTable> Data() {

            try {
                var dataTable = new DataTable();
                dataTable.Columns.Add("Nome");
                dataTable.Columns.Add("Tot.Teli");
                dataTable.Columns.Add("Tot.Capi");
                dataTable.Columns.Add("Tot. h lav.");
                dataTable.Columns.Add("Tot.Teli+Capi");
                dataTable.Columns.Add("media pz/h");

                var sdt = Central.DateFrom;
                var edt = Central.DateTo;
                var startDate = new DateTime(sdt.Year, sdt.Month, sdt.Day, 0, 0, 0);
                var endDate = new DateTime(edt.Year, edt.Month, edt.Day, 23, 59, 59);

                var mostraAttuale = Central.MostraAttuale;

                if (mostraAttuale) {
                    MessageBox.Show("Mostra atualle is not allowed for the report by big amout of date.",
                        "TelliProdotiPersone", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return Task.FromResult(dataTable); ;
                }
                else {
                    if (startDate.Date > endDate.Date) {
                        MessageBox.Show("Start date is greater end Date.",
                       "Invalid date selection", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return Task.FromResult(dataTable);
                    }
                }

                var totRow1 = dataTable.NewRow();
                var totRow2 = dataTable.NewRow();
                var totRow3 = dataTable.NewRow();

                dataTable.Rows.Add(totRow1);

                var startDateFlag = startDate.Date;
                var q = 0;

                for (var date = new DateTime(startDate.Year, startDate.Month, startDate.Day);
                    date <= new DateTime(endDate.Year, endDate.Month, endDate.Day); date = date.AddDays(+1)) {

                    dataTable.Columns.Add(date.ToString("dd-MM-yyyy") + "_teli");
                    dataTable.Columns.Add(date.ToString("dd-MM-yyyy") + "_capi");
                    dataTable.Columns.Add(date.ToString("dd-MM-yyyy") + "_h lav.");
                    dataTable.Columns.Add(date.ToString("dd-MM-yyyy") + "_pz/h");

                    dataTable.Rows[0][6 + q] = date.ToString("dddd-MMMM-yyyy", CultureInfo.InvariantCulture);
                    q += 4;
                }

                return Task.FromResult(dataTable);
            }
            catch {
                return null;
            }
        }
    }
}
