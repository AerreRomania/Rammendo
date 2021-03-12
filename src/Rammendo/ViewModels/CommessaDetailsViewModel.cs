using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rammendo.Models;
namespace Rammendo.ViewModels
{
    public class CommessaDetailsViewModel : BaseViewModel
    {
        private string Commessa { get; set; }
        private string Article { get; set; }
        
        public CommessaDetailsViewModel(string commessa) {
            Commessa = commessa;
        }

        public CommessaDetailsViewModel(string commessa, string article) {
            Commessa = commessa;
            Article = article;
        }

        public async Task<DataTable> Data(string commessa) {

            try {
                var dataTable = new DataTable();
                dataTable.Columns.Add("Color");
                dataTable.Columns.Add("Taglia");
                dataTable.Columns.Add("Componente");
                dataTable.Columns.Add("Pacchi");
                dataTable.Columns.Add("Barcode");
                dataTable.Columns.Add("Data I lett");
                dataTable.Columns.Add("Buoni");
                dataTable.Columns.Add("Tot.Teli al ram");
                dataTable.Columns.Add("T.Teli scar.tes");
                dataTable.Columns.Add("Tot.Teli Ramm");

                var commessaDetails = await ApiService.GetAll<CommessaDetails>("commessa="+commessa);

                DataRow totRow;
                DataRow totRow1;

                totRow1 = dataTable.NewRow();
                totRow1[0] = "Commessa";
                totRow1[1] = "Articolo";
                dataTable.Rows.Add(totRow1);
                totRow = dataTable.NewRow();
                totRow[0] = commessa;
                totRow[1] =  Article;
                dataTable.Rows.Add(totRow);

                var totQtyPack = 0;
                var totBarcodes = 0;
                var totTelliRam = 0.0;
                var totTelliScart = 0.0;

                foreach (var detail in commessaDetails) {

                    DataRow newRow = dataTable.NewRow();
                    newRow[0] = detail.Color;
                    newRow[1] = detail.Size;
                    newRow[2] = detail.Component;
                    newRow[3] = detail.QtyPack;
                    newRow[4] = detail.Barcode;
                    newRow[5] = detail.CreatedDate.ToString("dd-MM-yyyy");
                    newRow[6] = detail.Good;
                    newRow[7] = detail.Bad;
                    newRow[8] = detail.BadBad;
                    newRow[9] = detail.GoodGood;

                    dataTable.Rows.Add(newRow);

                    totQtyPack += detail.QtyPack;
                    totBarcodes++;
                    totTelliRam += Convert.ToDouble(detail.Bad);
                    totTelliScart += Convert.ToDouble(detail.BadBad);
                }

                var dbQtyPack = Convert.ToDouble(totQtyPack);

                var totRam = Math.Round(totTelliRam / dbQtyPack * 100,2);
                var totScart = Math.Round(totTelliScart / dbQtyPack * 100, 2);

                dataTable.Rows[1][3] = totQtyPack;
                dataTable.Rows[1][4] = totBarcodes;
                dataTable.Rows[1][7] = totRam + "%";
                dataTable.Rows[1][8] = totScart + "%";


                return dataTable;
            }
            catch {
                return null;
            }
        }
    }
}
