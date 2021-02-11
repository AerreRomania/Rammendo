using System;
using System.Collections.Generic;
using System.Text;

namespace CsvTransporter
{
    public static class CsvInfo
    {
        public const string CSV_PATH = "D:\\RammendoImport";
        public const string CONNECTION_STRING = "Data Source=192.168.96.37;Initial Catalog=Sinotico;Integrated Security=SSPI";
        public static string LastCsvFile { get; set; }
        public static int MaxIdentity { get; set; } = 0;
    }
}
