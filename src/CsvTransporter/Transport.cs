using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace CsvTransporter
{
    public class Transport
    {
        private readonly Log log = new Log();
        private DataTable _dataTable = new DataTable();

        public void TransportCsv() {
            try {
                var executionTime = DateTime.Now; // start time of exporting 

                //exact converted datetime dedicated to the file bellow
                var strNameByDate = DateTime.Now.ToString("dd-MM-yyyy");

                foreach (var file in Directory.GetFiles(CsvInfo.CSV_PATH)) {

                    var fileNameInDirectory = Path.GetFileNameWithoutExtension(file);

                    if (fileNameInDirectory != strNameByDate) continue;

                    //reset ID when new file appear [1]
                    if (CsvInfo.LastCsvFile != fileNameInDirectory) CsvInfo.MaxIdentity = 0;

                    using (StreamReader streamReader = new StreamReader(new FileStream(file, FileMode.Open, FileAccess.Read))) {

                        _dataTable = new DataTable();
                        CreateDedicatedColumns(_dataTable);

                        while (!streamReader.EndOfStream) {
                            string[] rows = streamReader.ReadLine().Split(';'); //check new ID
                            int.TryParse(rows[0].ToString(), out var maxIdentity); //read rows which contains ID greater last stored ID
                            if (maxIdentity < CsvInfo.MaxIdentity) continue;
                            
                            var newRow = _dataTable.NewRow();
                            for (var i = 1; i <= rows.Length - 1; i++) { newRow[i - 1] = rows[i]; }
                            _dataTable.Rows.Add(newRow);
                            
                            CsvInfo.MaxIdentity = maxIdentity; // store last ID in runtime (reset -> [1])
                        }
                        //always check for last opened file !
                        CsvInfo.LastCsvFile = fileNameInDirectory;
                    }
                }

                if (_dataTable.Rows.Count != 0) {
                    var connection = new SqlConnection(CsvInfo.CONNECTION_STRING);
                    //insert data via bulk copy from datatable
                    using (var sbc = new SqlBulkCopy(connection)) {
                        sbc.DestinationTableName = "RammendoImport";
                        connection.Open();
                        sbc.WriteToServer(_dataTable, DataRowState.Added);
                        connection.Close();
                        sbc.Close();
                    }

                    // Writes last extracted file status
                    var endTime = DateTime.Now;
                    var ms = endTime.Subtract(executionTime).TotalMilliseconds;
                    log.WriteLog(message:
                          $"CSV FILE {CsvInfo.LastCsvFile}.csv WITH {_dataTable.Rows.Count} rows loaded " +
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
        }
    }
}
