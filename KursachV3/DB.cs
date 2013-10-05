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
        static readonly SqlConnection Sqlc = new SqlConnection(Properties.Settings.Default.Database1ConnectionString);

        static bool Connect()
        {
            try
            {
                Sqlc.Open();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(string.Format("Ошибка подключения:\n{0}", ex.Message));
                return false;
            }

        }

        static void Disconnect()
        {
            try
            {
                Sqlc.Close();
            }
            catch (SqlException exception)
            {
                MessageBox.Show(string.Format("Ошибка закрытия подключения\n{0}", exception.Message));
            }
        }
        public static DataTable Select(string cols, string table, string sortColumn = "", string sortDestination = "",string where = "")
        {
            if (!Connect())
            {
                return null;
            }
            var dtable = new DataTable();
            var query = "SELECT " + cols + " FROM " + table;
            if (@where != "")
            {
                query += " WHERE " + @where;
            }
            if (sortColumn != "")
            {
                query += " order by " + sortColumn + " ";
            }
            if (sortDestination != "")
            {
                query += " " + sortDestination;
            }
            var command = Sqlc.CreateCommand();
            command.CommandText = query;
            try
            {
                var dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dtable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            Disconnect();
            return dtable;
        }

        public static bool Update(string table, Dictionary<string,object> update, int id = 0)
        {
            var command = new SqlCommand("UPDATE " + table + " SET ", Sqlc);
            command.CommandText += String.Join(",", update.Select(elem => elem.Key + "=@" + elem.Key));
            command = SetValues(update,command);
            if (id != 0)
            {
                command.CommandText += " WHERE id=" + id;
            }
            MessageBox.Show(command.CommandText);
            return Exec(command);    
        }
        public static bool Insert(string table, Dictionary<string,object> vars)
        {
            var sqlcom = Sqlc.CreateCommand();
            sqlcom.CommandText = "INSERT INTO " + table + " ";
            sqlcom.CommandText += "(" + String.Join(",", vars.Select(elem => elem.Key)) + ")";
            sqlcom.CommandText +=" VALUES ("; 
            sqlcom.CommandText += String.Join(",", vars.Select(elem => "@" + elem.Key));
            sqlcom = SetValues(vars, sqlcom);
            sqlcom.CommandText += ")";
            return Exec(sqlcom);
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
            if (Connect())
            {
                bool result = true;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(string.Format("Что-то пошло не так:\n{0}", ex.Message));
                    result = false;
                }
                Disconnect();
                return result;
            }
            return false;
        }

        public static bool Delete(string table, int id)
        {
                var sqlcom = Sqlc.CreateCommand();
                sqlcom.CommandText = "DELETE FROM " + table + " WHERE id =" + id;
                return Exec(sqlcom);
        }
    }
}

