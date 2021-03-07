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

        public async Task<DataTable> Data(string article, string commessa) {

            try {
                var dataTable = new DataTable();
                dataTable.Columns.Add("Articolo");
                dataTable.Columns.Add("Commessa");
                dataTable.Columns.Add("T. Prodoti");
                dataTable.Columns.Add("Rammendare");

                var reportFilter = new ReportFilter {
                    Article = article,
                    Commessa = commessa,
                    StartDate = Central.DateFrom,
                    EndDate = Central.DateTo
                };

                var telliProdotiArticolo = await ApiService.GetAllByFilter<TelliProdotiArticolo>(reportFilter);

                DataRow totRow;

                totRow = dataTable.NewRow();
                dataTable.Rows.Add(totRow);

                foreach (var telliProduct in telliProdotiArticolo) {

                    var newRow = dataTable.NewRow();
                    newRow[0] = telliProduct.Article;
                    newRow[1] = telliProduct.Stagione;
                    newRow[2] = telliProduct.Commessa;
                    newRow[3] = telliProduct.Finezza;
                    dataTable.Rows.Add(newRow);
                }
                
                return dataTable;
            }
            catch {
                return null;
            }
        }
    }
}
