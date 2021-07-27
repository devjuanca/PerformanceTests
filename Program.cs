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
            //Entity Framework Core
            Console.WriteLine("Selecionando 600000 filas usando SQL Server y Entity Framework Core - .ToListAsync()");
            await ApplyTests.EFCore_Test();

            Console.WriteLine();


            //Entity Framework Core & Stored Procedure
            Console.WriteLine("Selecionando 600000 filas usando SQL Server y Entity Framework Core con Procedimiento Almacenado - .FromSqlRaw()");
            await ApplyTests.EFCoreWithStoredProcedure_Test();

            Console.WriteLine();


            //Dapper Core & Stored Procedure
            Console.WriteLine("Selecionando 600000 filas usando SQL Server y Dapper con Procedimiento Almacenado");
            await ApplyTests.DapperWithStoredProcedure_Test();

            Console.WriteLine();

            //Sql Client & Stored Procedure
            Console.WriteLine("Selecionando 600000 filas usando SQL Server y SqlClient con Procedimiento Almacenado");
            await ApplyTests.SqlClientWithStoredProcedure_Test();

            Console.ReadLine();
        }
    }
}
