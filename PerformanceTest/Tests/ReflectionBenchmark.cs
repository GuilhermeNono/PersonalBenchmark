using BenchmarkDotNet.Attributes;
using PerformanceTest.Model;

namespace PerformanceTest.Tests;

[Config(typeof(AntiVirusFriendlyConfig))]
[MemoryDiagnoser]
public class ReflectionBenchmark
{
    [Benchmark]
    public Person Activator_Test() => Instantiate<Person>();

    private T Instantiate<T>()
    {
        return Activator.CreateInstance<T>();
    }
    
    private T InstantiateByConstructor<T>() where T : class, new()
    {
        return new T();
    }

    [Benchmark]
    public Person Constructor_Test() => InstantiateByConstructor<Person>();
}