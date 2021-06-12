using System;
using System.Diagnostics;

namespace PerformanceTests
{
    class Program
    {
       static void Main(string[] args)
        {
           
            Console.WriteLine("Inserting 2000 rows using EF Core 3.1");
            Console.WriteLine(DataWork.InsertingDataEF());
          
            Console.WriteLine("Inserting 2000 rows using Plumbing Code");
            Console.WriteLine(DataWork.InsertingDataPlumbing());

            Console.WriteLine("Inserting 2000 rows using Dapper");
            Console.WriteLine(DataWork.InsertingDataDapper());

            Console.ReadLine();
        }
    }
}
