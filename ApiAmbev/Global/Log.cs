using ApiAmbev.Controllers;
using ApiAmbev.DataBase;
using Npgsql;
using ApiAmbev.DataBase;

namespace ApiAmbev.Global
{
    public class Log
    {
        public static void Add(LogType type, string message)
        {
            try
            {
                if (type == LogType.success && !Convert.ToBoolean(Config.logSuccessEnabled))
                    return;

                else if (type == LogType.info && !Convert.ToBoolean(Config.logInfoEnabled))
                    return;

                else if (type == LogType.error && !Convert.ToBoolean(Config.logErrorEnabled))
                    return;

                else
                {
                    
                        SaveLogToDatabase(type, message);
                }
            }
            catch
            { }
        }

        private static void SaveLogToDatabase(LogType type, string message)
        {
            DataBaseAccess dba = new DataBaseAccess();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"INSERT INTO logs (creation_date, type, message) " +
                                      @"VALUES (@creationDate, @type, @message);";


                    cmd.Parameters.AddWithValue("@creationDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@type", type.ToString());
                    cmd.Parameters.AddWithValue("@message", message);

                    using (cmd.Connection = dba.OpenConnection())
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            { }
        }

    }
}
