namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Creature e = new Elf("Elrond", 10, 12);
        Elf elf = new("Legolas", 5, 7);
        Console.WriteLine(e.Greetings());
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
        //TestElfsAndOrcs();
        //TestValidators();
        TestObjectsToString();
    }

    static void TestValidators()
    {
        Creature c;

        c = new Elf("   Shrek    ", 20, 5);
        Console.WriteLine(c.Greetings());
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new Orc("  ", -5, -3);
        Console.WriteLine(c.Greetings());
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new Elf("  donkey ", 7, 3);
        Console.WriteLine(c.Greetings());
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new Orc("Puss in Boots – a clever and brave cat.", 1, 2);
        Console.WriteLine(c.Greetings());
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new Elf("a                            troll name", 5, 9);
        Console.WriteLine(c.Greetings());
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
        Console.WriteLine(o.Greetings());
        for (int i = 0; i < 10; i++)
        {
            o.Hunt();
            Console.WriteLine(o.Greetings());
        }

        Console.WriteLine("\nSING TEST\n");
        var e = new Elf("Legolas", agility: 2);
        Console.WriteLine(e.Greetings());
        for (int i = 0; i < 10; i++)
        {
            e.Sing();
            Console.WriteLine(e.Greetings());
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
    static void TestObjectsToString()
    {
        object[] myObjects = {
        new Animals() { Description = "dogs"},
        new Birds { Description = "  eagles ", Size = 10 },
        new Elf("e", 15, -3),
        new Orc("morgash", 6, 4)
    };
        Console.WriteLine("\nMy objects:");
        foreach (var o in myObjects) Console.WriteLine(o);
        /*
            My objects:
            ANIMALS: Dogs <3>
            BIRDS: Eagles (fly+) <10>
            ELF: E## [10][0]
            ORC: Morgash [6][4]
        */
    }
}
