using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace KursachV3
{
    class Db
    {
        readonly SqlConnection _sqlc;

        public Db(string connectionString)
        {
            _sqlc = new SqlConnection(connectionString);
        }
        bool Connect()
        {
            try
            {
                _sqlc.Open();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(string.Format("Ошибка подключения:\n{0}", ex.Message));
                return false;
            }

        }
        void Disconnect()
        {
            try
            {
                _sqlc.Close();
            }
            catch (SqlException exception)
            {
                MessageBox.Show(string.Format("Ошибка закрытия подключения\n{0}", exception.Message));
            }
        }
        public DataTable Select(string cols, string table, string sortColumn = "", string sortDestination = "",string where = "")
        {
            if (!Connect())
            {
                return null;
            }
            var dtable = new DataTable();
            var query = "SELECT " + cols + " FROM " + table + " ";
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
                query += sortDestination;
            }

            var command = _sqlc.CreateCommand();
            command.CommandText = query;

            var dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(dtable);
            Disconnect();
            return dtable;
        }

        public bool Update(string table, Dictionary<string,object> update, int id = 0)
        {
                var command = new SqlCommand("UPDATE " + table + " SET ", _sqlc);
                int counter = 0;
                //command.CommandText += String.Join(",", update.Select(elem => elem.Key + "=@" + elem.Value));
                foreach (var key in update.Keys)
                {
                    command.CommandText += key + "=@" + key;
                    command.Parameters.AddWithValue(key, update[key]);
                    counter++;
                    if (counter != update.Keys.Count())
                    {
                        command.CommandText += ",";
                    }
                }
                if (id != 0)
                {
                    command.CommandText += " WHERE id=" + id;
                }
                return Exec(command);
        }
        public bool Insert(string table, Dictionary<string,object> vars)
        {
            SqlCommand sqlcom = _sqlc.CreateCommand();
            sqlcom.CommandText = "INSERT INTO " + table + " VALUES ("; 
                //key=@key,
            int counter = 0;
            foreach (var key in vars.Keys)
            {
                sqlcom.CommandText += "@" + key;
                sqlcom.Parameters.AddWithValue(key, vars[key]);
                counter++;
                if (counter != vars.Keys.Count())
                {
                    sqlcom.CommandText += ",";
                }
            }
            sqlcom.CommandText += ")";
            return Exec(sqlcom);
        }
        bool Exec(SqlCommand command)
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

        public bool Delete(string table, int id)
        {
                var sqlcom = _sqlc.CreateCommand();
                sqlcom.CommandText = "DELETE FROM " + table + " WHERE id =" + id;
                return Exec(sqlcom);
        }
    }
}

