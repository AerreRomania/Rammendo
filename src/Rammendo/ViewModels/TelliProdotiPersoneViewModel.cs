using Rammendo.Models;
using Rammendo.Models.Filters;
using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rammendo.ViewModels
{
    public class TelliProdotiPersoneViewModel : BaseViewModel
    {
        public async Task<DataTable> Data() {

            try {
                var dataTable = new DataTable();
                dataTable.Columns.Add("Nr");
                dataTable.Columns.Add("Nome");
                dataTable.Columns.Add("Tot.Teli");
                dataTable.Columns.Add("Tot.Capi");
                dataTable.Columns.Add("Tot. H lav.");
                dataTable.Columns.Add("Tot.\nTeli+Capi");
                dataTable.Columns.Add("Media pz/H");

                var sdt = Central.DateFrom;
                var edt = Central.DateTo;
                var startDate = new DateTime(sdt.Year, sdt.Month, sdt.Day, 0, 0, 0);
                var endDate = new DateTime(edt.Year, edt.Month, edt.Day, 23, 59, 59);

                if (startDate.Date > endDate.Date) {
                    MessageBox.Show("Start date is greater end Date.",
                   "Invalid date selection", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return dataTable;
                }

                var reportFilter = new ReportFilter {
                    StartDate = startDate,
                    EndDate = endDate
                };

                var prodotiPersons = await ApiService.GetAllByFilter<TelliProdotiPersone>(reportFilter);

                var totRow1 = dataTable.NewRow();
                var totRow2 = dataTable.NewRow();
                var totRow3 = dataTable.NewRow();

                dataTable.Rows.Add(totRow1);

                var startDateFlag = startDate.Date;
                var q = 0;

                for (var date = new DateTime(startDate.Year, startDate.Month, startDate.Day);
                    date <= new DateTime(endDate.Year, endDate.Month, endDate.Day); date = date.AddDays(+1)) {

                    dataTable.Columns.Add(date.ToString("MM-dd-yyyy") + "_Teli");
                    dataTable.Columns.Add(date.ToString("MM-dd-yyyy") + "_Capi");
                    dataTable.Columns.Add(date.ToString("MM-dd-yyyy") + "_H lav.");
                    dataTable.Columns.Add(date.ToString("MM-dd-yyyy") + "_Pz/H");

                    dataTable.Rows[0][7 + q] = date.ToString("dddd, MMMM dd, yy", CultureInfo.InvariantCulture);
                    q += 4;
                }

                var htbl = new Hashtable();
                var idx = 1;

                foreach (var prodotiPerson in prodotiPersons) {
                    var hKey = prodotiPerson.Angajat;

                    if (htbl.ContainsKey(hKey)) {
                        var rn = Convert.ToInt32(htbl[hKey]);

                        if (prodotiPerson.TypeOfControl == "Telli") {
                            dataTable.Rows[rn][prodotiPerson.CreatedDate + "_" + "Teli"] = prodotiPerson.Rammendati;
                        }
                        else if (prodotiPerson.TypeOfControl == "Capi") {
                            dataTable.Rows[rn][prodotiPerson.CreatedDate + "_" + "Capi"] = prodotiPerson.Rammendati;
                        }
                    }
                    else {
                        var newRow = dataTable.NewRow();
                        newRow[0] = idx;
                        newRow[1] = prodotiPerson.Angajat;

                        if (prodotiPerson.TypeOfControl == "Telli") {
                            newRow[prodotiPerson.CreatedDate+"_"+"Teli"] = prodotiPerson.Rammendati;
                        }
                        else if (prodotiPerson.TypeOfControl == "Capi") {
                            newRow[prodotiPerson.CreatedDate + "_" + "Capi"] = prodotiPerson.Rammendati;
                        }

                        dataTable.Rows.Add(newRow);
                        htbl.Add(hKey, idx);
                        idx++;
                    }

                }

                return dataTable;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
