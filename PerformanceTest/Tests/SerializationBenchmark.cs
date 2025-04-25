using System.Text.Json;
using BenchmarkDotNet.Attributes;
using PerformanceTest.Model;
using StackExchange.Redis;

namespace PerformanceTest.Tests;

public class SerializationBenchmark
{
    private ConnectionMultiplexer connection = ConnectionMultiplexer.Connect("localhost");
    private readonly IDatabase _database;

    public SerializationBenchmark()
    {
        _database = connection.GetDatabase();
    }

    [Benchmark]
    public Person? Return_SerializeAndDeserializeObject()
    {
        var person = new Person()
        {
            Age = 21,
            Birthdate = DateTime.Now,
            Cpf = "999999999",
            Id = 1,
            Name = "Guilherme",
            State = "SP"
        };

        var personSerilized = JsonSerializer.Serialize(person);

        return JsonSerializer.Deserialize<Person>(personSerilized);
    }
    
    [Benchmark]
    public string Return_DeserializeAndSerializeObject()
    {
        var json =
            "{\"Id\":1,\"Name\":\"Guilherme\",\"Age\":21,\"Birthdate\":\"2024-01-04\",\"Cpf\":\"999999999\",\"Cnpj\":null,\"Rg\":\"53303587574\",\"Cnh\":null,\"State\":\"SP\"}";

        var personDeserialized = JsonSerializer.Deserialize<Person>(json);

        return JsonSerializer.Serialize(personDeserialized);
    }

    [Benchmark]
    public Person? Return_OnlyObject() => new()
    {
        Age = 21,
        Birthdate = DateTime.Now,
        Cpf = "999999999",
        Id = 1,
        Name = "Guilherme",
        State = "SP"
    };

    [Benchmark]
    public string Return_OnlyTextJson() => "{\"Id\":1,\"Name\":\"Guilherme\",\"Age\":21,\"Birthdate\":\"2024-01-04\",\"Cpf\":\"999999999\",\"Cnpj\":null,\"Rg\":\"53303587574\",\"Cnh\":null,\"State\":\"SP\"}";
    
}