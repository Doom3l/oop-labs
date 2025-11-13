using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Creature
{
    public string Name { get; set; }
    
    private int level = 1;
    public int Level
    {
        get => level;
        set => level = value > 0 ? value : 1;
    }

    public Creature(string name, int level)
    {
        Name = name;
        Level = level;
    }

    public void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, level {Level} creature.");
    }

    public string Info()
    {
        return $"{Name} [{Level}]";
    }
}
