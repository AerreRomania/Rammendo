using System;
using System.IO;

namespace CsvTransporter
{
    public class Log
    {
        public void WriteLog(string message) {
            var sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "Log.txt", true);
            sw.WriteLine(DateTime.Now + ": " + message);
            sw.Flush();
            sw.Close();
        }
    }
}