// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using TokenPerformance;

Console.WriteLine("Hello, World!");
BenchmarkRunner.Run<HttpHeaderBenchmark>();