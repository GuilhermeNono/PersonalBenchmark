// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;
using PerformanceTest.Tests;

// var config = new ManualConfig()
//     .WithOptions(ConfigOptions.DisableOptimizationsValidator)
//     .AddValidator(JitOptimizationsValidator.DontFailOnError)
//     .AddLogger(ConsoleLogger.Default)
//     .AddColumnProvider(DefaultColumnProviders.Instance);

// BenchmarkRunner.Run<SerializationBenchmark>(config);
BenchmarkRunner.Run<ReflectionBenchmark>(ManualConfig.Create(DefaultConfig.Instance)
    .WithSummaryStyle(SummaryStyle.Default.WithRatioStyle(RatioStyle.Percentage))
    .WithOrderer(new DefaultOrderer(SummaryOrderPolicy.FastestToSlowest)));
