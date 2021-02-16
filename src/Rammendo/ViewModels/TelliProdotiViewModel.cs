using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Rammendo.Dom.Repositories;
using Rammendo.Dom.Repositories.Interfaces;

namespace Rammendo.ViewModels
{
    public class TelliProdotiViewModel
    {
        private readonly ITelliProdotiRepository _itelliProdotiRepository;

        public TelliProdotiViewModel() {
            _itelliProdotiRepository = new TelliProdotiRepository();
        }

        public async Task<DataTable> Data() {

            var dataTable = new DataTable();
            dataTable.Columns.Add("Article");
            dataTable.Columns.Add("Commessa");
            dataTable.Columns.Add("T. Prodoti");
            dataTable.Columns.Add("Rammendare");

            var telliProdoti = await _itelliProdotiRepository.GetAll();
            var firstArticle = telliProdoti.FirstOrDefault().Article;
            DataRow totRow;
            
            foreach (var telliProduct in telliProdoti) {
                
                DataRow newRow;

                if (firstArticle == telliProduct.Article) {
                    newRow = dataTable.NewRow();
                    newRow[1] = telliProduct.Commessa;
                    newRow[2] = telliProduct.Prodoti;
                    newRow[3] = telliProduct.Rammendare;
                    dataTable.Rows.Add(newRow);
                }
                else {
                    totRow = dataTable.NewRow();
                    totRow[0] = $"Totale {firstArticle}";
                    dataTable.Rows.Add(totRow);

                    newRow = dataTable.NewRow();
                    newRow[1] = telliProduct.Commessa;
                    newRow[2] = telliProduct.Prodoti;
                    newRow[3] = telliProduct.Rammendare;
                    dataTable.Rows.Add(newRow);
                }

                firstArticle = telliProduct.Article;
            }
            totRow = dataTable.NewRow();
            totRow[0] = $"Totale {firstArticle}";
            dataTable.Rows.Add(totRow);

            return dataTable;
        }
    }
}
