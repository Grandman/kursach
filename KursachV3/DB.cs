using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace KursachV3
{
    static class Db
    {
        static readonly string ConnectionString = Properties.Settings.Default.Database1ConnectionString;

        public static DataTable Select(string cols, string table, string sortColumn = "", string sortDestination = "", string where = "")
        {
            using (SqlConnection sqlc = new SqlConnection(ConnectionString))
            {
                var dtable = new DataTable();
                var query = "SELECT " + cols + " FROM " + table;
                if (@where != "")
                {
                    query += " WHERE " + @where;
                }
                if (sortColumn != "")
                {
                    query += " order by " + sortColumn;
                }
                if (sortDestination != "")
                {
                    query += " " + sortDestination;
                }
                var command = sqlc.CreateCommand();
                command.CommandText = query;
                var dataAdapter = new SqlDataAdapter(command);
                try
                {
                    dataAdapter.Fill(dtable);
                }
                catch (Exception exception)
                {

                    MessageBox.Show("Ошибка заполнения таблицы: " + exception.Message +"\n" +command.CommandText + "\nПриложение завершит работу");
                    Application.Exit();
                }
                return dtable;
            }
        }

        public static bool Update(string table, Dictionary<string,object> update, int id = 0)
        {
            using (SqlConnection sqlc = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand("UPDATE " + table + " SET ", sqlc);
                command.CommandText += String.Join(",", update.Select(elem => elem.Key + "=@" + elem.Key));
                command = SetValues(update, command);
                if (id != 0)
                {
                    command.CommandText += " WHERE id=" + id;
                }
                return Exec(command);
            }
        }
        public static bool Insert(string table, Dictionary<string,object> vars)
        {
            using (SqlConnection sqlc = new SqlConnection(ConnectionString))
            {
                var sqlcom = sqlc.CreateCommand();
                sqlcom.CommandText = "INSERT INTO " + table + " ";
                sqlcom.CommandText += "(" + String.Join(",", vars.Select(elem => elem.Key)) + ")";
                sqlcom.CommandText += " VALUES (";
                sqlcom.CommandText += String.Join(",", vars.Select(elem => "@" + elem.Key));
                sqlcom = SetValues(vars, sqlcom);
                sqlcom.CommandText += ")";
                return Exec(sqlcom);
            }
        }

        private static SqlCommand SetValues(Dictionary<string, object> vars, SqlCommand sqlcom)
        {
            foreach (var key in vars.Keys)
            {
                sqlcom.Parameters.AddWithValue(key, vars[key]);
            }
            return sqlcom;
        }

        static bool Exec(SqlCommand command)
        {
                return command.ExecuteNonQuery() >= 1;
        }

        public static bool Delete(string table, int id)
        {
            using (SqlConnection sqlc = new SqlConnection(ConnectionString))
            {
                var sqlcom = sqlc.CreateCommand();
                sqlcom.CommandText = "DELETE FROM " + table + " WHERE id=" + id;
                return Exec(sqlcom);
            }
        }
    }
}

