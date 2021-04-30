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
        public async Task<DataView> Data() {

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

                    return dataTable.DefaultView;
                }

                var reportFilter = new ReportFilter {
                    StartDate = startDate,
                    EndDate = endDate
                };

                var prodotiPersons = await ApiService.GetAllByFilter<TelliProdotiPersone>(reportFilter);

                var totRow1 = dataTable.NewRow();
 
                dataTable.Rows.Add(totRow1);
                totRow1[1] = "TOTALE";

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

                var totTeli = 0;
                var totCapi = 0;
                var totDuration = 0;
                var totPezzi = 0.0;

                var totTotTeli = 0;
                var totTotCapi = 0;
                var totTotDuration = 0;
                var totTotPezzi = 0.0;

                foreach (var prodotiPerson in prodotiPersons) {
                    var hKey = prodotiPerson.Angajat;

                    if (htbl.ContainsKey(hKey)) {
                        var rn = Convert.ToInt32(htbl[hKey]);

                        if (prodotiPerson.TypeOfControl == "Telli") {
                            dataTable.Rows[rn][prodotiPerson.CreatedDate + "_" + "Teli"] = prodotiPerson.Rammendati;
                            totTeli += prodotiPerson.Rammendati;
                            totTotTeli += prodotiPerson.Rammendati;
                            dataTable.Rows[rn][2] = totTeli;
                        }
                        else if (prodotiPerson.TypeOfControl == "Capi") {
                            dataTable.Rows[rn][prodotiPerson.CreatedDate + "_" + "Capi"] = prodotiPerson.Rammendati;
                            totCapi += prodotiPerson.Rammendati;
                            totTotCapi += prodotiPerson.Rammendati;
                            dataTable.Rows[rn][3] = totCapi;
                        }

                        dataTable.Rows[rn][prodotiPerson.CreatedDate + "_" + "H lav."] = TimeSpan.FromSeconds(totDuration).ToString(@"hh\:mm");
                        dataTable.Rows[rn][prodotiPerson.CreatedDate + "_" + "Pz/H"] = Math.Round(prodotiPerson.PezziH, 2);

                        totDuration += prodotiPerson.Duration;
                        totPezzi += Math.Round(prodotiPerson.PezziH, 2);
                        totTotDuration += prodotiPerson.Duration;
                        totTotPezzi += Math.Round(prodotiPerson.PezziH, 2);

                        dataTable.Rows[rn][4] = TimeSpan.FromSeconds(totDuration).ToString(@"hh\:mm");
                        dataTable.Rows[rn][5] = totTeli + totCapi;
                        dataTable.Rows[rn][6] = totPezzi;
                    }
                    else {
                        var newRow = dataTable.NewRow();
                        totTeli = 0;
                        totCapi = 0;
                        totDuration = 0;
                        totPezzi = 0.0;

                        newRow[0] = idx;
                        newRow[1] = prodotiPerson.Angajat;

                        if (prodotiPerson.TypeOfControl == "Telli") {
                            newRow[prodotiPerson.CreatedDate+"_"+"Teli"] = prodotiPerson.Rammendati;
                            totTeli = prodotiPerson.Rammendati;
                            newRow[2] = totTeli;
                            totTotTeli += prodotiPerson.Rammendati;
                        }
                        else if (prodotiPerson.TypeOfControl == "Capi") {
                            newRow[prodotiPerson.CreatedDate + "_" + "Capi"] = prodotiPerson.Rammendati;
                            totCapi = prodotiPerson.Rammendati;
                            newRow[3] = totCapi;
                            totTotCapi += prodotiPerson.Rammendati;
                        }

                        newRow[prodotiPerson.CreatedDate + "_" + "H lav."] = TimeSpan.FromSeconds(prodotiPerson.Duration).ToString(@"hh\:mm");
                        newRow[prodotiPerson.CreatedDate + "_" + "Pz/H"] = Math.Round(prodotiPerson.PezziH, 2);
                        totDuration += prodotiPerson.Duration;
                        totPezzi += Math.Round(prodotiPerson.PezziH, 2);
                        totTotDuration += prodotiPerson.Duration;
                        totTotPezzi += Math.Round(prodotiPerson.PezziH, 2);

                        newRow[4] = TimeSpan.FromSeconds(totDuration).ToString(@"hh\:mm");
                        newRow[5] = totTeli + totCapi;
                        newRow[6] = totPezzi;

                        dataTable.Rows.Add(newRow);
                        htbl.Add(hKey, idx);
                        idx++;
                    }
                }

                totRow1[2] = totTotTeli;
                totRow1[3] = totTotCapi;
                totRow1[4] = TimeSpan.FromSeconds(totTotDuration).ToString(@"hh\:mm");
                totRow1[5] = totTotTeli + totTotCapi;
                totRow1[6] = totTotPezzi.ToString();

                return dataTable.DefaultView;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message + '\n' + ex.StackTrace);
                return null;
            }
        }
    }
}
