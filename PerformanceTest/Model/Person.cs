namespace PerformanceTest.Model;

public class Person
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public DateTime Birthdate { get; set; }
    public string Cpf { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
}