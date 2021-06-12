using Dapper;
using Microsoft.Data.SqlClient;
using PerformanceTests.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTests
{
    public static class DataWork
    {

        public static string InsertingDataEF()
        {
            try
            {
                PerformanceTestContext _ctx = new PerformanceTestContext();
                List<Data> l = new List<Data>();
                for (int i = 0; i < 2000; i++)
                {
                    l.Add(new Data
                    {
                        Date = DateTime.Now.ToString(),
                        Guid = Guid.NewGuid().ToString()
                    }); ;
                }
                Stopwatch stop_watch = Stopwatch.StartNew();
                _ctx.AddRange(l);
                _ctx.SaveChanges();
                TimeSpan checkPoint = stop_watch.Elapsed;
                return checkPoint.ToString();
            }
            catch (Exception e) { return e.Message; }
        }

        public static string InsertingDataPlumbing()
        {
            try
            {

                List<Data> l = new List<Data>();
                for (int i = 0; i < 2000; i++)
                {
                    l.Add(new Data
                    {
                        Date = DateTime.Now.ToString(),
                        Guid = Guid.NewGuid().ToString()
                    }); ;
                }
                Stopwatch stop_watch = Stopwatch.StartNew();
                SqlConnection conex = new SqlConnection("Data Source=.;Initial Catalog=PerformanceTest;Integrated Security=True");
                conex.Open();
                foreach (var d in l)
                {
                    SqlCommand command = new SqlCommand($"insert into Data values ('{d.Date}',' {d.Guid.ToString()}')", conex);
                    command.ExecuteNonQuery();
                }
                conex.Close();


                TimeSpan checkPoint = stop_watch.Elapsed;
                return checkPoint.ToString();
            }
            catch (Exception e) { return e.Message; }
        }
        public static string InsertingDataDapper()
        {
            List<Data> l = new List<Data>();
            for (int i = 0; i < 2000; i++)
            {
                l.Add(new Data
                {
                    Date = DateTime.Now.ToString(),
                    Guid = Guid.NewGuid().ToString()
                }); ;
            }
            Stopwatch stop_watch = Stopwatch.StartNew();
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=PerformanceTest;Integrated Security=True");

            conn.Open();
            foreach (var d in l)
            {
                
                conn.Execute($"insert into Data values ('{d.Date}',' {d.Guid.ToString()}')");
            }
            TimeSpan checkPoint = stop_watch.Elapsed;
            return checkPoint.ToString();
        }

    }
}

