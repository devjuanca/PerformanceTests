using SqlClient.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SqlClient
{
    public static class SqlClientBigQuery
    {
        public static async Task<IEnumerable<Data>> GetData()
        {
            using SqlConnection conex = new(@"Data Source=HP-PERSONAL\LOCALSQLSERVER;Initial Catalog=OrmTests;Integrated Security=True");
            {
                conex.Open();
                List<Data> data = new();
                SqlCommand command = new("GetData", conex)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var dataReader = await command.ExecuteReaderAsync();
                while (dataReader.Read())
                {
                    data.Add(new Data
                    {
                        Id = Convert.ToInt32(dataReader[0]),
                        Item1 = dataReader[1].ToString(),
                        Item2 = dataReader[2].ToString(),
                        Item3 = dataReader[3].ToString(),
                        Item4 = dataReader[4].ToString(),
                        Item5 = dataReader[5].ToString(),
                        Item6 = dataReader[6].ToString(),
                        Item7 = dataReader[7].ToString(),
                        Item8 = dataReader[8].ToString(),
                        Item9 = dataReader[9].ToString(),
                        Item10 = dataReader[10].ToString(),
                    });
                }

                return data;


            }

        }
    }
}
