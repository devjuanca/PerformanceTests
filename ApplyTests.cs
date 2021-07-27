using CustomTimer;
using DapperORM;
using EFCore;
using SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTests
{
    public static class ApplyTests
    {
        public static async Task EFCore_Test ()
        {
            Timer.Start();
            await EFBigQuery.GetData();
            Timer.End();
            
            Console.WriteLine(Timer.Duration());
        }

        public static async Task EFCoreWithStoredProcedure_Test()
        {
            Timer.Start();
            await EFBigQueryStoredProcedure.GetData();
            Timer.End();
            
            Console.WriteLine(Timer.Duration());
        }

        public static async Task DapperWithStoredProcedure_Test()
        {
            Timer.Start();
            await DapperBigQuery.GetData();
            Timer.End();
            
            Console.WriteLine(Timer.Duration());
        }

        public static async Task SqlClientWithStoredProcedure_Test()
        {
            Timer.Start();
            await SqlClientBigQuery.GetData();
            Timer.End();
            
            Console.WriteLine(Timer.Duration());
        }

    }
}
