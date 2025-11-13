namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");

        var dogs = new Animals
        {
            Description = "Dogs",
            Size = 3
        };

        Console.WriteLine(dogs.Info);
    }
}
