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

                var strNameByDate = DateTime.Now.ToString("dd-MM-yyyy"); // converted datetime dedicated to the file bellow

                foreach (var file in Directory.GetFiles(CsvInfo.CSV_PATH)) {
                    var fileName = Path.GetFileNameWithoutExtension(file);
                    if (fileName != strNameByDate) continue;

                    if (CsvInfo.LastCsvFile != fileName) CsvInfo.MaxIdentity = 0; //reset ID when new file appear [1]

                    using (StreamReader sr = new StreamReader(new FileStream(file, FileMode.Open, FileAccess.Read))) {
                        
                        _dataTable = new DataTable();
                        _dataTable.Columns.Add("Commessa");
                        _dataTable.Columns.Add("Article");
                        _dataTable.Columns.Add("Color");
                        _dataTable.Columns.Add("Gradient");
                        _dataTable.Columns.Add("Size");
                        _dataTable.Columns.Add("Component");
                        _dataTable.Columns.Add("QtyPack");
                        _dataTable.Columns.Add("Barcode");
                        _dataTable.Columns.Add("Good");
                        _dataTable.Columns.Add("Bad");

                        while (!sr.EndOfStream) {
                            string[] rows = sr.ReadLine().Split(';');
                            int.TryParse(rows[0].ToString(), out var maxIdentity); //check new ID
                            if (maxIdentity < CsvInfo.MaxIdentity) continue; //read rows which contains ID greater last stored ID

                            //import into datatable
                            var newRow = _dataTable.NewRow();
                            for (var i = 1; i <= rows.Length - 1; i++) {
                                newRow[i - 1] = rows[i];
                            }
                            _dataTable.Rows.Add(newRow);

                            // store last ID in runtime (reset -> [1])
                            CsvInfo.MaxIdentity = maxIdentity;
                        }

                        //always check for last opened file !
                        CsvInfo.LastCsvFile = fileName;
                    }
                }

                /*
                 insert data view bulk copy from datatable
                 */
                if (_dataTable.Rows.Count != 0) {
                    var connection = new SqlConnection(CsvInfo.CONNECTION_STRING);

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
    }
}
