using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rammendo.Dom.Entities;
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

            if (telliProdoti == null) {
                MessageBox.Show("No data", nameof(TelliProdoti), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return await Task.FromResult(dataTable);
            }

            var totProdoti = 0;
            var totRamendare = 0;
            var totTotProdoti = 0;
            var totTotRammendare = 0;

            var firstArticle = telliProdoti.FirstOrDefault().Article;
            DataRow totRow;

            totRow = dataTable.NewRow();
            dataTable.Rows.Add(totRow);

            foreach (var telliProduct in telliProdoti) {
                
                DataRow newRow;

                if (firstArticle == telliProduct.Article) {
                    newRow = dataTable.NewRow();
                    newRow[1] = telliProduct.Commessa;
                    newRow[2] = telliProduct.Prodoti;
                    newRow[3] = telliProduct.Rammendare;
                    dataTable.Rows.Add(newRow);
                    totProdoti += telliProduct.Prodoti;
                    totRamendare += telliProduct.Rammendare;
                }
                else {
                    totRow = dataTable.NewRow();
                    totRow[0] = $"Totale {firstArticle}";
                    totRow[2] = totProdoti;
                    totRow[3] = totRamendare;
                    dataTable.Rows.Add(totRow);

                    totProdoti = 0;
                    totRamendare = 0;
                    newRow = dataTable.NewRow();
                    newRow[1] = telliProduct.Commessa;
                    newRow[2] = telliProduct.Prodoti;
                    newRow[3] = telliProduct.Rammendare;
                    totProdoti += telliProduct.Prodoti;
                    totRamendare += telliProduct.Rammendare;
                    dataTable.Rows.Add(newRow);
                }
                totTotProdoti += totProdoti;
                totTotRammendare += totRamendare;

                firstArticle = telliProduct.Article;
            }
            totRow = dataTable.NewRow();
            totRow[0] = $"Totale {firstArticle}";
            totRow[2] = totProdoti;
            totRow[3] = totRamendare;
            dataTable.Rows.Add(totRow);

            dataTable.Rows[0][0] = "TOTALE";
            dataTable.Rows[0][2] = totTotProdoti;
            dataTable.Rows[0][3] = totTotRammendare;

            return dataTable;
        }
    }
}
