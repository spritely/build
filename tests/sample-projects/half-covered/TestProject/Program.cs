namespace TestProject;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello from shared test project");
    }

    public static string Covered(string input)
    {
        return input;
    }

    public static string Uncovered(string input)
    {
        return input;
    }
}
