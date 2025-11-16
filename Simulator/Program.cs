namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        object s = "I am object";
        object i = 5;
        object e = new Elf() { Name = "Legolas", Agility = 3 };

        object[] objects = new object[] { s, i, e };

        foreach (var o in objects)
        {
            Console.WriteLine($"{o.GetType(),-15}: {o}");
        }
        //Creature e = new Elf("Elrond", 10, 12);
        //Elf elf = new("Legolas", 5, 7);
        //e.SayHi();
        //e.Upgrade();
        //if (e is Elf)
        //{
        //    (e as Elf)?.Sing();
        //}
        //else
        //{
        //  Console.WriteLine($"{e.Name} is not an elf.");
        //}

        //Console.WriteLine(e.Info);

        //e.Go(Direction.Left);
    }
}
