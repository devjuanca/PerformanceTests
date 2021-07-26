using CustomTimer;
using DapperORM;
using EFCore;
using SqlClient;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PerformanceTests
{
    class Program
    {
       static async Task Main(string[] args)
        {
            Timer.Start();
            await EFBigQuery.GetData();
            Timer.End();
            Console.WriteLine("Selecting 600000 rows from SQL Server using Entity Framework Core");
            Console.WriteLine(Timer.Duration());

            Console.WriteLine("\n");

            Timer.Start();
            await EFBigQueryStoredProcedure.GetData();
            Timer.End();
            Console.WriteLine("Selecting 600000 rows from SQL Server using Entity Framework Core and Stored Procedure");
            Console.WriteLine(Timer.Duration());

            Console.WriteLine("\n");

            Timer.Start();
            await SqlClientBigQuery.GetData();
            Timer.End();
            Console.WriteLine("Selecting 600000 rows from SQL Server using SqlClient and Stored Procedure");
            Console.WriteLine(Timer.Duration());

            Console.WriteLine("\n");

            Timer.Start();
            await DapperBigQuery.GetData();
            Timer.End();
            Console.WriteLine("Selecting 600000 rows from SQL Server using Dapper and Stored Procedure");
            Console.WriteLine(Timer.Duration());


        }
    }
}
