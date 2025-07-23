namespace TestProject;

public static class Class1
{
    public static string Covered(string input)
    {
        return input;
    }

    public static string Uncovered(string input)
    {
        return input;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello from dotnet-container");
    }

    public static string Covered(string input)
    {
        return input;
    }
}
