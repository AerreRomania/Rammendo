﻿using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;

namespace CsvImporter
{
    public class Importer
    {
        private readonly Log _log = new Log();
        private DataTable _dataTable = new DataTable();

        private List<string> _listOfBarcodesBuffer = new List<string>();

        private void CreateColumnsForBulkUpdate(DataTable dataTable)
        {
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
            dataTable.Columns.Add("ComenziArticolId", typeof(int));
            dataTable.Columns.Add("CreatedDate", typeof(DateTime));
            dataTable.Columns.Add("GoodGood", typeof(int));
            dataTable.Columns.Add("BadBad", typeof(int));
            dataTable.Columns.Add("Diff", typeof(int));
            dataTable.Columns.Add("Angajat");
            dataTable.Columns.Add("Reparto");
            dataTable.Columns.Add("TypeOfControl");
            dataTable.Columns.Add("Tavolo");
            dataTable.Columns.Add("CapiH", typeof(double));
            dataTable.Columns.Add("IdStagione", typeof(int));
            dataTable.Columns.Add("IdFinezze", typeof(int));
            dataTable.Columns.Add("StartJob", typeof(DateTime));
            dataTable.Columns.Add("EndJob", typeof(DateTime));
            dataTable.Columns.Add("TeamRammendo", typeof(int));
            dataTable.Columns.Add("QtyProgram", typeof(int));
        }

        public void Import() {
            try {
                var startImportTime = DateTime.Now;
                var strNameByDate = DateTime.Now.ToString("dd-MM-yyyy");

                var lstOfBarcodes = CsvInfo.GetInsertedBarcodes(strNameByDate);
                _listOfBarcodesBuffer = new List<string>();

                foreach (var file in Directory.GetFiles(CsvInfo.CSV_PATH)) {
                    var fileName = Path.GetFileNameWithoutExtension(file);
                    if (fileName != strNameByDate) continue;
                   
                    _dataTable = new DataTable();

                    CreateColumnsForBulkUpdate(_dataTable);

                    var commessaInfo = CsvInfo.GetCommessa();
                    var maxKey = CsvInfo.GetMaxKeyBasedOnImport(fileName);
                    
                    using (StreamReader streamReader = new StreamReader(new FileStream(file, FileMode.Open, FileAccess.Read))) { 
                        while (!streamReader.EndOfStream) {
                            string[] rows = streamReader.ReadLine().Split(';');

                            int.TryParse(rows[0].ToString(), out var maxIdentityKey);
                            var barcode = rows[8].ToString();
                            int.TryParse(rows[11].ToString(), out var teamRammendo);

                            if (lstOfBarcodes.Contains(barcode) || _listOfBarcodesBuffer.Contains(barcode)) //update factory
                            {
                                CsvInfo.UpdateBarcode(barcode, teamRammendo);
                                continue;
                            }

                            if (maxIdentityKey <= maxKey) continue; //check only for new data

                            var cr = rows[1].Split('-');    //get commessa array by (-) to get regulation by the protocol of inserting
                            var regularCommessa = $"{cr[0]}{cr[1]}.{cr[2]}";

                            var newRow = _dataTable.NewRow(); 
                            for (var i = 1; i <= rows.Length - 2; i++) {
                                newRow[i - 1] = i == 1 ? regularCommessa : rows[i]; // ? commessa will be inserted regularly by 'onlyou' direction.
                            }
                            newRow[10] = maxIdentityKey;
                            newRow[11] = fileName;
                            var commessa = commessaInfo.FirstOrDefault(x => x.NrCommanda == regularCommessa && x.Article == rows[2]);
                            newRow[12] = commessa != null ? commessa.CommessaId : 0;
                            newRow[13] = commessa != null ? commessa.ArticleId : 0;
                            newRow[14] = DateTime.Now;
                            newRow[15] = 0;
                            newRow[16] = 0;
                            newRow[17] = 0;
                            newRow[18] = null; 
                            newRow[19] = null;
                            newRow[20] = null;
                            newRow[21] = null;
                            newRow[22] = commessa != null ? commessa.CapiH : 0.0;
                            newRow[23] = commessa != null ? commessa.IdStagione : 0;
                            newRow[24] = commessa != null ? commessa.IdFinezze : 0;
                            newRow[25] = DBNull.Value;
                            newRow[26] = DBNull.Value;
                            newRow[27] = teamRammendo;
                            newRow[28] = 0;

                            _dataTable.Rows.Add(newRow);

                            _listOfBarcodesBuffer.Add(rows[8].ToString());
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
    }
}
