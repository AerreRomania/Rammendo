using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace CsvImporter
{
    public class Importer
    {
        private readonly Log log = new Log();
        private DataTable _dataTable = new DataTable();

        public void Import() {
            try {
                var executionTime = DateTime.Now;
                var strNameByDate = DateTime.Now.ToString("dd-MM-yyyy");

                foreach (var file in Directory.GetFiles(CsvInfo.CSV_PATH)) {
                    var fileName = Path.GetFileNameWithoutExtension(file);
                    if (fileName != strNameByDate) continue;

                    log.WriteLog("[ACCESS] Trying to access and read " + fileName + ".csv\n" + Path.GetFullPath(file));

                    _dataTable = new DataTable();
                    CreateDedicatedColumns(_dataTable);

                    var maxKey = CsvInfo.GetMaxKey(fileName);

                    using (StreamReader streamReader = new StreamReader(new FileStream(file, FileMode.Open, FileAccess.Read))) { 
                        while (!streamReader.EndOfStream) {
                            string[] rows = streamReader.ReadLine().Split(';');
                            int.TryParse(rows[0].ToString(), out var maxIdentity);
                           
                            if (maxIdentity > maxKey) {
                                var newRow = _dataTable.NewRow();
                                for (var i = 1; i <= rows.Length - 1; i++) { newRow[i - 1] = rows[i]; }
                                newRow[10] = maxIdentity;
                                newRow[11] = fileName;
                                _dataTable.Rows.Add(newRow);
                            }
                        }
                    }
                }

                if (_dataTable.Rows.Count == 0) {
                    log.WriteLog(message: "[EMPTY] File " + strNameByDate + ".csv has been opened correctly but no new records were loaded.");
                    return;
                }

                if (_dataTable.Rows.Count != 0) {
                    var connection = new SqlConnection(CsvInfo.CONNECTION_STRING);

                    using (var sbc = new SqlBulkCopy(connection)) {
                        sbc.DestinationTableName = "RammendoImport";
                        connection.Open();
                        sbc.WriteToServer(_dataTable, DataRowState.Added);
                        connection.Close();
                        sbc.Close();
                    }

                    var ms = DateTime.Now.Subtract(executionTime).TotalMilliseconds;
                    log.WriteLog(message:
                          $"CSV FILE {strNameByDate}.csv WITH {_dataTable.Rows.Count} rows loaded " +
                          $"with status [OK]; " +
                          $"Estimated time: {ms}ms");
                }
            }
            catch (UnauthorizedAccessException uex) {
                log.WriteLog(message: "! Deny " + uex.Message);
            }
            catch (Exception ex) {
                log.WriteLog(message: "! Deny " + ex.Message);
            }
        }

        private void CreateDedicatedColumns(DataTable dataTable) {
            dataTable.Columns.Add("Commessa");
            dataTable.Columns.Add("Article");
            dataTable.Columns.Add("Color");
            dataTable.Columns.Add("Gradient");
            dataTable.Columns.Add("Size");
            dataTable.Columns.Add("Component");
            dataTable.Columns.Add("QtyPack");
            dataTable.Columns.Add("Barcode");
            dataTable.Columns.Add("Good");
            dataTable.Columns.Add("Bad");
            dataTable.Columns.Add("LastKey");
            dataTable.Columns.Add("FileKey");
        }
    }
}
