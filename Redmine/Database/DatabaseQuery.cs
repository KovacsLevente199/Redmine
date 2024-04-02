using System.Data.SqlClient;

namespace Redmine.Database
{
    public class DatabaseQuery
    {
        public DatabaseQuery(string CommandText) 
        {
            string ConnectionCredentials = "";

            using(SqlConnection connection = new SqlConnection(ConnectionCredentials)) 
            {
                try
                {
                    connection.Open();

                    SqlCommand query = new SqlCommand(CommandText, connection);
                    SqlDataReader reader = query.ExecuteReader();

                    while (reader.Read())
                    {
                        SortedDictionary<string, object> row = new SortedDictionary<string, object>();   
                        for(int i = 0; i < reader.FieldCount; i++)
                        {
                            row[reader.GetName(i)] = reader.GetValue(i);
                        }

                        rows.Add(row);
                    }
                    connection.Close();
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.ToString());   
                }
            }
        }

        private List<SortedDictionary<string, object>> rows = new List<SortedDictionary<string, object>>();
    }
}
