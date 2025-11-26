using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Simulator;

public abstract class Creature
{
    private string name = "Unknown";

    public string Name
    {
        get => name;
        init => name = Validator.Shortener(value, 3, 25, '#');
    }
    
    private int level = 1;
    public int Level
    {
        get => level;
        init => level = Validator.Limiter(value, 1, 10);
    }

    public Creature() { }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public abstract void SayHi();

    public string Info => $"{Name} [{Level}]";
    public void Upgrade()
    {
        if (level < 10)
            level++;
    }
    public void Go(Direction direction)
    {
        string dir = direction.ToString().ToLower();
        Console.WriteLine($"{Name} goes {dir}.");
    }

    public void Go(Direction[] directions)
    {
        foreach (var d in directions)
            Go(d);
    }

    public void Go(string input)
    {
        var dirs = DirectionParser.Parse(input);
        Go(dirs);
    }

    public abstract int Power { get; }
}
