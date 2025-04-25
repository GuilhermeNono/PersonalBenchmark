using BenchmarkDotNet.Attributes;
using PerformanceTest.Model;

namespace PerformanceTest.Tests;

public class EnumBenchmark
{
    [Benchmark]
    public void Random_Converter_Enum_With_Int_Type()
    {
        Random test = new Random();
        int num;
        TestEnumInt numEnum;
        for (int i = 0; i < 1000; i++)
        {
             num = test.Next(1, 5);
             numEnum = (TestEnumInt)num;
        }
    }
    
    [Benchmark]
    public void Random_Converter_Enum_With_Byte_Type()
    {
        Random test = new Random();
        int num;
        TestEnumByte numEnum;
        for (int i = 0; i < 1000; i++)
        {
            num = test.Next(1, 5);
            numEnum = (TestEnumByte)num;
        }
    }
}