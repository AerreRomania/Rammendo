using System;
using System.Data;
using System.Data.SqlClient;

namespace Rammendo
{
    public static class Globals
    {
        public static string ResetFilter = "<Reset>";

        public static DateTime GetNextStartTime(string operat)
        {
            var dt = DateTime.MinValue;

            var qry = "SELECT MAX(EndTime) FROM RammendoSchedule " +
               "WHERE Operator=@Operator;";

            try
            {
                using (var c = new SqlConnection(Central.CONNECTION_STRING))
                {
                    var cmd = new SqlCommand(qry, c);
                    cmd.Parameters.Add("@Operator", SqlDbType.NVarChar).Value = operat;

                    c.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            DateTime.TryParse(dr[0].ToString(), out dt);
                        }
                    }
                    else
                    {
                        dt = DateTime.MinValue;
                    }

                    c.Close();
                }
            }
            catch (Exception)
            {
                
            }

            return dt;
        }

        public static int GetNextIndex(string operat, DateTime? updateTime = null)
        {
            var index = 0;

            var qry = "SELECT MAX(Idx) FROM RammendoSchedule " +
               "WHERE Operator=@Operator";

            if (updateTime != null)
            {
                qry += " AND EndTime <= @UpdateTime";
            }

            try
            {
                using (var c = new SqlConnection(Central.CONNECTION_STRING))
                {
                    var cmd = new SqlCommand(qry, c);
                    cmd.Parameters.Add("@Operator", SqlDbType.NVarChar).Value = operat;
                    
                    if (updateTime != null)
                    {
                        cmd.Parameters.Add("@UpdateTime", SqlDbType.DateTime).Value = updateTime;
                    }

                    c.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            int.TryParse(dr[0].ToString(), out index);
                        }
                    }
                    else
                    {
                        index = 0;
                    }

                    c.Close();
                }
            }
            catch (Exception)
            {

            }

            return index + 1;
        }
    }
}
