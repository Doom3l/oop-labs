namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Creature e = new Elf("Elrond", 10, 12);
        Elf elf = new("Legolas", 5, 7);
        e.SayHi();
        e.Upgrade();
        if (e is Elf)
        {
            (e as Elf)?.Sing();
        }
        else
        {
          Console.WriteLine($"{e.Name} is not an elf.");
        }

        Console.WriteLine(e.Info);

        e.Go(Direction.Left);
        TestElfsAndOrcs();
        TestValidators();
    }

    static void TestValidators()
    {
        Creature c;

        c = new Elf("   Shrek    ", 20, 5);
        c.SayHi();
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new Orc("  ", -5, -3);
        c.SayHi();
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new Elf("  donkey ", 7, 3);
        c.SayHi();
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new Orc("Puss in Boots – a clever and brave cat.", 1, 2);
        c.SayHi();
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new Elf("a                            troll name", 5, 9);
        c.SayHi();
        c.Upgrade();
        Console.WriteLine(c.Info);

        var a = new Animals() { Description = "   Cats " };
        Console.WriteLine(a.Info);

        a = new Animals() { Description = "Mice           are great", Size = 40 };
        Console.WriteLine(a.Info);
    }


    static void TestElfsAndOrcs()
    {
        Console.WriteLine("HUNT TEST\n");
        var o = new Orc() { Name = "Gorbag", Rage = 7 };
        o.SayHi();
        for (int i = 0; i < 10; i++)
        {
            o.Hunt();
            o.SayHi();
        }

        Console.WriteLine("\nSING TEST\n");
        var e = new Elf("Legolas", agility: 2);
        e.SayHi();
        for (int i = 0; i < 10; i++)
        {
            e.Sing();
            e.SayHi();
        }

        Console.WriteLine("\nPOWER TEST\n");
        Creature[] creatures = {
        o,
        e,
        new Orc("Morgash", 3, 8),
        new Elf("Elandor", 5, 3)
    };
        foreach (Creature creature in creatures)
        {
            Console.WriteLine($"{creature.Name,-15}: {creature.Power}");
        }
    }
}
