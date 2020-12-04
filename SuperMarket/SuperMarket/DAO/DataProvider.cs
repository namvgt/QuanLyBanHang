using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.DAO
{
    class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataProvider();
                return DataProvider.instance;
            }
            private set
            {
                DataProvider.instance = value;
            }
        }
        private DataProvider() { }
        string ConnectionStr = "Data Source = .; Initial Catalog = SupperMarkett; Integrated Security = True";
        public DataTable ExecuteQuery(string query, object[] parameter = null) {
            DataTable data = new DataTable();
     
            using (SqlConnection connection = new SqlConnection(ConnectionStr)) 
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
         }
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach(string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();
                
                connection.Close();
            }
            return data;
        }
       public string DuLieu(string query)
        {
            string ID;
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                connection.Open();
                
                SqlDataAdapter Adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                Adapter.Fill(dt);
                ID = dt.Rows[0][0].ToString();
            }
            return ID;
        }
       
    }
}
