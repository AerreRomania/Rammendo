using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Rammendo.Helpers.ScheduleOrganizer
{
    public class Organize
    {
        private JobParams GetIndexBeforeTargetDateTime(DateTime targetDateTime, string operat, string line)
        {
            var lst = new List<JobParams>();
            
            var qry = @"
SELECT Idx,EndTime FROM RammendoSchedule WHERE Operator=@Operator AND Line=@Line AND CONVERT(NVARCHAR, EndTime, 110) <= @EndTime
ORDER BY EndTime;";

            using (var c = new SqlConnection(Central.CONNECTION_STRING))
            {
                var cmd = new SqlCommand(qry, c);
                cmd.Parameters.Add("@Operator", System.Data.SqlDbType.NVarChar).Value = operat;
                cmd.Parameters.Add("@Line", System.Data.SqlDbType.NVarChar).Value = line;
                cmd.Parameters.Add("@EndTime", System.Data.SqlDbType.NVarChar).Value = targetDateTime.ToString("dd-MM-yyyy");

                c.Open();
                var dr = cmd.ExecuteReader();
                if (dr.HasRows)
                    while (dr.Read())
                    {
                        int.TryParse(dr[0].ToString(), out var idx);
                        DateTime.TryParse(dr[1].ToString(), out var endTime);

                        lst.Add(new JobParams(idx, endTime));
                    }
                c.Close();
            }

            if (lst == null || lst.Count == 0)
            {
                return null;
            }
            else
            {
                return lst.Last();
            }
        }

        public void MoveTask(DateTime targetDateTime, DateTime startTime, DateTime dateTime, string operat, string line, string key)
        {
            var jobParam = GetIndexBeforeTargetDateTime(targetDateTime, operat, line);

            var idx = jobParam != null ? jobParam.Idx + 1 : 1;
            var start = jobParam != null ? jobParam.EndTime : targetDateTime;
            var end = start.AddTicks(dateTime.Subtract(startTime).Ticks);

            var qry = "UPDATE RammendoSchedule SET Idx=Idx+1 WHERE Operator=@Operator AND Line=@Line AND Idx>@Idx";
            var qry1 = "UPDATE RammendoSchedule SET Operator=@Operator, Line=@Line, Idx=@Idx, StartTime=@StartTime, EndTime=@EndTime WHERE CONCAT(Id,'_',Barcode) = '" + key + "'";

            using (var c = new SqlConnection(Central.CONNECTION_STRING))
            {
                var cmd = new SqlCommand(qry, c);
                cmd.Parameters.Add("@Operator", System.Data.SqlDbType.NVarChar).Value = operat;
                cmd.Parameters.Add("@Line", System.Data.SqlDbType.NVarChar).Value = line;
                cmd.Parameters.Add("@Idx", System.Data.SqlDbType.Int).Value = idx;

                c.Open();
                var dr = cmd.ExecuteNonQuery();

                cmd = new SqlCommand(qry1, c);
                cmd.Parameters.Add("@Operator", System.Data.SqlDbType.NVarChar).Value = operat;
                cmd.Parameters.Add("@Line", System.Data.SqlDbType.NVarChar).Value = line;
                cmd.Parameters.Add("@Idx", System.Data.SqlDbType.Int).Value = idx;
                cmd.Parameters.Add("@StartTime", System.Data.SqlDbType.NVarChar).Value = start;
                cmd.Parameters.Add("@EndTime", System.Data.SqlDbType.NVarChar).Value = end;

                var dr1 = cmd.ExecuteNonQuery();
                c.Close();
            }
        }

        internal class JobParams
        {
            public int Idx { get; set; }
            public DateTime EndTime { get; set; }

            public JobParams(int idx, DateTime dateTime)
            {
                Idx = idx;
                EndTime = dateTime;
            }
        }
    }
}
