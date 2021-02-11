using System;
using System.Collections.Generic;
using System.Text;

namespace CsvTransporter
{
    public static class CsvInfo
    {
        public const string CSV_PATH = "D:\\RammendoImport";
        public const string CONNECTION_STRING = "data source=192.168.96.37;initial catalog=ONLYOU; User ID=nicu; password=onlyouolimpias;";
        public static string LastCsvFile { get; set; }
        public static int MaxIdentity { get; set; } = 0;
    }
}
