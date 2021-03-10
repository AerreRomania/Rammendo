using Rammendo.Models;
using Rammendo.Models.Filters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<DataTable> Data(string article, string commessa, string stagione, string finezze) {

            try {
                var dataTable = new DataTable();
                dataTable.Columns.Add("Articolo");
                dataTable.Columns.Add("Stagione");
                dataTable.Columns.Add("Commessa");
                dataTable.Columns.Add("Finezza");
                dataTable.Columns.Add("Buoni-DaRammendare");
                dataTable.Columns.Add("Buoni");
                dataTable.Columns.Add("DaRammendare");
                dataTable.Columns.Add("Rammendati");
                dataTable.Columns.Add("Scarti");

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
                dataTable.Rows.Add(totRow);

                foreach (var telliProduct in telliProdotiArticolo) {

                    var newRow = dataTable.NewRow();
                    newRow[0] = telliProduct.Article;
                    newRow[1] = telliProduct.Stagione;
                    newRow[2] = telliProduct.Commessa;
                    newRow[3] = telliProduct.Finezza;
                    newRow[4] = telliProduct.BuoniDaRammendare;
                    newRow[5] = telliProduct.Buoni;
                    newRow[6] = telliProduct.DaRammendare;
                    newRow[7] = telliProduct.Rammendati;
                    newRow[8] = telliProduct.Scarti;

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
                    if (!ListStagione.Contains(telliProduct.Finezza) && telliProduct.Finezza != null) {
                        ListStagione.Add(telliProduct.Finezza);
                    }
                }

                return dataTable;
            }
            catch {
                return null;
            }
        }
    }
}
