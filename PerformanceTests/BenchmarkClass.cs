using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Order;
using DapperORM;
using EFCore;
using SqlClient;
using System.Threading.Tasks;

namespace PerformanceTests;

[SimpleJob(RunStrategy.Monitoring, launchCount: 1, warmupCount: 5, targetCount: 5, id: "FastAndDirtyJob")]
[MemoryDiagnoser]
[Orderer(summaryOrderPolicy: SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class BenchmarkClass
{
    [Benchmark]
    public async Task EFCoreToListAsync()
    {
        await EFBigQuery.GetData();
    }

    [Benchmark]
    public async Task EFCoreWithStoredProcedure()
    {
        await EFBigQueryStoredProcedure.GetData();
    }

    [Benchmark]
    public async Task DapperWithStoredProcedure()
    {
        await DapperBigQuery.GetData();
    }

    [Benchmark]
    public async Task ADOWithStoredProcedure()
    {
        await SqlClientBigQuery.GetData();
    }
}
