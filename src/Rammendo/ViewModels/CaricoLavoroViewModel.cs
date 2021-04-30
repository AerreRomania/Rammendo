using Rammendo.Models;
using Rammendo.Models.Filters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Rammendo.ViewModels
{
    public class CaricoLavoroViewModel : BaseViewModel
    {
        public List<string> ListArticles { get; set; }
        public List<string> ListCommesse { get; set; }
        public List<string> ListFinezze { get; set; }

        public async Task<DataView> Data(string article, string commessa, string finezze)
        {            
            try
            {
                var dataTable = new DataTable();
                dataTable.Columns.Add("Commessa");
                dataTable.Columns.Add("Articolo");
                dataTable.Columns.Add("Fin");
                dataTable.Columns.Add("Qta\nCommessa", typeof(int));
                dataTable.Columns.Add("Qta buono", typeof(int));
                dataTable.Columns.Add("Qta\nda rammendare", typeof(int));
                dataTable.Columns.Add("Qta\nrammendata", typeof(int));
                dataTable.Columns.Add("Qta scarti", typeof(int));
                dataTable.Columns.Add("Diff", typeof(int));
                dataTable.Columns.Add("Data\nlettura");
                dataTable.Columns.Add("Data\nramandare");
                dataTable.Columns.Add("Data\narrivo");
                dataTable.Columns.Add("Data\nconsegna");
                dataTable.Columns.Add("DVC");
                dataTable.Columns.Add("RDD");

                var sdt = Central.DateFrom;
                var edt = Central.DateTo;
                var startDate = new DateTime(sdt.Year, sdt.Month, sdt.Day, 0, 0, 0);
                var endDate = new DateTime(edt.Year, edt.Month, edt.Day, 23, 59, 59);

                var mostraAttuale = Central.MostraAttuale;

                if (mostraAttuale)
                {
                    startDate = startDate.AddYears(-10);
                    endDate = endDate.AddYears(+1);
                }

                var reportFilter = new ReportFilter
                {
                    Article = article,
                    Commessa = commessa,
                    Stagione = null,
                    Finezze = finezze,
                    StartDate = startDate,
                    EndDate = endDate
                };

                var caricoLavoro = await ApiService.GetAllByFilter<CaricoLavoro>(reportFilter);

                ListArticles = new List<string>();
                ListCommesse = new List<string>();
                ListFinezze = new List<string>();

                DataRow totRow;

                totRow = dataTable.NewRow();
                totRow[0] = "TOTALE";
                for (var i = 3; i <= 8; i++)
                {
                    totRow[i] = 0; //set total default value
                }

                dataTable.Rows.Add(totRow);

                foreach (var cl in caricoLavoro)
                {
                    var newRow = dataTable.NewRow();

                    newRow[0] = cl.Commessa;
                    newRow[1] = cl.Article;
                    newRow[2] = cl.Finezza;
                    newRow[3] = cl.TotalQty;
                    newRow[4] = cl.Good;
                    newRow[5] = cl.Bad;
                    newRow[6] = cl.GoodGood;
                    newRow[7] = cl.BadBad;
                    newRow[8] = cl.Bad - (cl.GoodGood + cl.BadBad);
                    newRow[9] = cl.DataLettura.ToString("dd-MM-yyyy");
                    newRow[10] = null;
                    newRow[11] = null;
                    newRow[12] = null;
                    newRow[13] = null;
                    newRow[14] = null;

                    dataTable.Rows.Add(newRow);

                    if (!ListArticles.Contains(cl.Article))
                    {
                        ListArticles.Add(cl.Article);
                    }
                    if (!ListCommesse.Contains(cl.Commessa))
                    {
                        ListCommesse.Add(cl.Commessa);
                    }
                    if (!ListFinezze.Contains(cl.Finezza) && cl.Finezza != null)
                    {
                        ListFinezze.Add(cl.Finezza);
                    }

                    for (var i = 3; i <= 8; i++)
                    {
                        var total = Convert.ToInt32(totRow[i]);
                        var rowVal = Convert.ToInt32(newRow[i]);
                        totRow[i] = total + rowVal;
                    }
                }

                return dataTable.DefaultView;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Workers>> LoadNames()
        {
            var lst = await ApiService.GetAll<Workers>();

            return lst;
        }
    }
}
