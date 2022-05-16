using DapperORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace DapperORM
{
    public static class DapperBigQuery
    {
        public static async Task<IEnumerable<Data>> GetData()
        {
            using SqlConnection conn = new SqlConnection(@"Data Source=HP-PERSONAL\LOCALSQLSERVER;Initial Catalog=OrmTests;Integrated Security=True");
            {
                List<Data> data = new List<Data>();

                conn.Open();

                var dataReader = await conn.ExecuteReaderAsync("GetData", commandType: System.Data.CommandType.StoredProcedure);
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
