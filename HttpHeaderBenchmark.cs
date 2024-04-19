using BenchmarkDotNet.Attributes;
using Microsoft.AspNetCore.Http;

namespace TokenPerformance;

[MemoryDiagnoser]
public class HttpHeaderBenchmark
{
    private readonly IHeaderDictionary Headers = new HeaderDictionary();
    
    // write a benchmark startup code to init headers
    [GlobalSetup]
    public void GlobalSetup()
    {
        Headers.Add("Authorization", "Bearer ExpectedValue");
    }

    [Benchmark]
    public void GetAuthorizationTokenValue()
    {
        Headers.GetAuthorizationTokenValue();   
    }
    
    [Benchmark]
    public void SimpleHeader()
    {
        HttpHeaderExtensions.SimpleHeader(Headers);
    }
    
    [Benchmark]
    public void GetAuthTokenValue()
    {
        Headers.GetAuthTokenValue();
    }
}