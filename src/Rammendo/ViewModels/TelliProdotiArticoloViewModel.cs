using Rammendo.Models;
using Rammendo.Models.Filters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rammendo.ViewModels
{
    public class TelliProdotiArticoloViewModel : BaseViewModel
    {
        public TelliProdotiArticoloViewModel() {
        }

        public List<string> ListArticles { get; set; }
        public List<string> ListCommesse { get; set; }
        public List<string> ListStagione { get; set; }
        public List<string> ListFinezze { get; set; }

        public async Task<DataView> Data(string article, string commessa, string stagione, string finezze, bool includeAll = true) {

            try {
                var dataTable = new DataTable();
                dataTable.Columns.Add("Articolo");
                dataTable.Columns.Add("Stagione");
                dataTable.Columns.Add("Commessa");
                dataTable.Columns.Add("Finezza");
                dataTable.Columns.Add("Buoni+\nDaRammendare",typeof(int));
                dataTable.Columns.Add("Buoni", typeof(int));
                dataTable.Columns.Add("Da\nRammendare", typeof(int));
                dataTable.Columns.Add("Rammendati", typeof(int));
                dataTable.Columns.Add("Diff", typeof(int));
                dataTable.Columns.Add("TIM\nRammendo", typeof(int));
                dataTable.Columns.Add("Scarti", typeof(int));
                dataTable.Columns.Add("% Rammendati");
                dataTable.Columns.Add("% Scarti");
                dataTable.Columns.Add("% Rammendo");

                var sdt = Central.DateFrom;
                var edt = Central.DateTo;
                var startDate = new DateTime(sdt.Year, sdt.Month, sdt.Day, 0, 0, 0);
                var endDate = new DateTime(edt.Year, edt.Month, edt.Day, 23, 59, 59);

                var mostraAttuale = Central.MostraAttuale;

                if (mostraAttuale) {
                    startDate = startDate.AddYears(-10);
                    endDate = endDate.AddYears(+1);
                }

                var reportFilter = new ReportFilter {
                    Article = article,
                    Commessa = commessa,
                    Stagione = stagione,
                    Finezze = finezze,
                    StartDate = startDate,
                    EndDate = endDate
                };

                var telliProdotiArticolo = await ApiService.GetAllByFilter<TelliProdotiArticolo>(reportFilter);

                ListArticles = new List<string>();
                ListCommesse = new List<string>();
                ListStagione = new List<string>();
                ListFinezze = new List<string>();

                DataRow totRow;

                totRow = dataTable.NewRow();
                totRow[0] = "TOTALE";
                for (var i = 4; i <= 10; i++) {
                    totRow[i] = 0; //set total default value
                }

                dataTable.Rows.Add(totRow);

                foreach (var telliProduct in telliProdotiArticolo) {
                    if (!includeAll && telliProduct.DaRammendare == 0) continue;

                    var newRow = dataTable.NewRow();
                    newRow[0] = telliProduct.Article;
                    newRow[1] = telliProduct.Stagione;
                    newRow[2] = telliProduct.Commessa;
                    newRow[3] = telliProduct.Finezza;
                    newRow[4] = telliProduct.BuoniDaRammendare;
                    newRow[5] = telliProduct.Buoni;
                    newRow[6] = telliProduct.DaRammendare;
                    newRow[7] = telliProduct.Rammendati;
                    newRow[8] = telliProduct.DaRammendare - telliProduct.Rammendati;
                    newRow[9] = telliProduct.TeamRammendo;
                    newRow[10] = telliProduct.Scarti;

                    var rammendatiEff = Math.Round(Convert.ToDouble(telliProduct.Rammendati) / Convert.ToDouble(telliProduct.BuoniDaRammendare) * 100.0, 2);
                    var scartiEff = Math.Round(Convert.ToDouble(telliProduct.Scarti) / Convert.ToDouble(telliProduct.BuoniDaRammendare) * 100.0, 2);
                    var rammendoEff = Math.Round(Convert.ToDouble(telliProduct.DaRammendare) / Convert.ToDouble(telliProduct.BuoniDaRammendare) * 100.0, 2);
                    if (double.IsNaN(rammendoEff) || double.IsInfinity(rammendoEff)) rammendoEff = 0;

                    newRow[11] = $"{rammendatiEff}%";
                    newRow[12] = $"{scartiEff}%";
                    newRow[13] = $"{rammendoEff}%";

                    dataTable.Rows.Add(newRow);

                    if (!ListArticles.Contains(telliProduct.Article)) {
                        ListArticles.Add(telliProduct.Article);
                    }
                    if (!ListCommesse.Contains(telliProduct.Commessa)) {
                        ListCommesse.Add(telliProduct.Commessa);
                    }
                    if (!ListStagione.Contains(telliProduct.Stagione) && telliProduct.Stagione != null) {
                        ListStagione.Add(telliProduct.Stagione);
                    }
                    if (!ListFinezze.Contains(telliProduct.Finezza) && telliProduct.Finezza != null) {
                        ListFinezze.Add(telliProduct.Finezza);
                    }

                    for (var i = 4; i <= 10; i++)
                    {
                        var total = Convert.ToInt32(totRow[i]);
                        var rowVal = Convert.ToInt32(newRow[i]);
                        totRow[i] = total + rowVal;
                    }
                }

                if (totRow[11] != null && totRow[12] != null && totRow[13] != null)
                {
                    totRow[11] = $"{Math.Round(Convert.ToDouble(totRow[7]) / Convert.ToDouble(totRow[4]) * 100.0, 2)}%";
                    totRow[12] = $"{Math.Round(Convert.ToDouble(totRow[10]) / Convert.ToDouble(totRow[4]) * 100.0, 2)}%";
                    totRow[13] = $"{Math.Round(Convert.ToDouble(totRow[6]) / Convert.ToDouble(totRow[4]) * 100.0, 2)}%";
                }

                return dataTable.DefaultView;
            }
            catch (Exception) {
                return null;
            }
        }
    }
}
