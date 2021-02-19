using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CsvImporter
{
    public class Importer
    {
        private readonly Log _log = new Log();
        private DataTable _dataTable = new DataTable();

        public void Import() {
            try {
                var startImportTime = DateTime.Now;
                var strNameByDate = DateTime.Now.ToString("dd-MM-yyyy");

                foreach (var file in Directory.GetFiles(CsvInfo.CSV_PATH)) {
                    var fileName = Path.GetFileNameWithoutExtension(file);
                    if (fileName != strNameByDate) continue;

                    _dataTable = new DataTable();
                    CreateDedicatedColumns(_dataTable);
                    var commessaInfo = CsvInfo.GetCommessa();

                    var maxKey = CsvInfo.GetMaxKeyBasedOnImport(fileName);

                    using (StreamReader streamReader = new StreamReader(new FileStream(file, FileMode.Open, FileAccess.Read))) { 
                        while (!streamReader.EndOfStream) {
                            string[] rows = streamReader.ReadLine().Split(';');
                            int.TryParse(rows[0].ToString(), out var maxIdentityKey);
                            if (maxIdentityKey <= maxKey) continue; 

                            var newRow = _dataTable.NewRow();
                            for (var i = 1; i <= rows.Length - 1; i++) { newRow[i - 1] = rows[i]; }
                            newRow[10] = maxIdentityKey;
                            newRow[11] = fileName;

                            var commessa = commessaInfo.FirstOrDefault(x => x.NrCommanda == rows[1] && x.Article == rows[2]);
                            newRow[12] = commessa != null ? commessa.CommessaId : 0;
                            newRow[13] = commessa != null ? commessa.ArticleId : 0;
                            newRow[14] = DateTime.Now;

                            _dataTable.Rows.Add(newRow);
                        }
                    }
                }

                if (_dataTable.Rows.Count != 0) {
                    using (var sbc = new SqlBulkCopy(CsvInfo.CONNECTION_STRING, SqlBulkCopyOptions.Default)) {
                        sbc.DestinationTableName = "RammendoImport";
                        sbc.WriteToServer(_dataTable, DataRowState.Added);
                    }

                    var ms = DateTime.Now.Subtract(startImportTime).TotalMilliseconds;
                    _log.WriteLog(message:
                          $"CSV FILE {strNameByDate}.csv WITH {_dataTable.Rows.Count} rows loaded " +
                          $"with status [OK]; " +
                          $"Estimated time: {ms}ms");
                }
            }
            catch (UnauthorizedAccessException uex) {
                _log.WriteLog(message: "! Deny " + uex.Message);
            }
            catch (Exception ex) {
                _log.WriteLog(message: "! Deny " + ex.Message);
            }
        }

        private void CreateDedicatedColumns(DataTable dataTable) {
            dataTable.Columns.Add("Commessa");
            dataTable.Columns.Add("Article");
            dataTable.Columns.Add("Color");
            dataTable.Columns.Add("Gradient");
            dataTable.Columns.Add("Size");
            dataTable.Columns.Add("Component");
            dataTable.Columns.Add("QtyPack", typeof(int));
            dataTable.Columns.Add("Barcode");
            dataTable.Columns.Add("Good", typeof(int));
            dataTable.Columns.Add("Bad", typeof(int));
            dataTable.Columns.Add("LastKey", typeof(int));
            dataTable.Columns.Add("FileKey");
            dataTable.Columns.Add("ComenziId", typeof(int));
            dataTable.Columns.Add("ComeziArticolId", typeof(int));
            dataTable.Columns.Add("CreatedDate", typeof(DateTime));
        }
    }
}
