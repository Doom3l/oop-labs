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

    public abstract string Greetings();

    public abstract string Info { get;  }
    public void Upgrade()
    {
        if (level < 10)
            level++;
    }
    public string Go(Direction direction)
        => direction.ToString().ToLower();

    public string[] Go(Direction[] directions)
        => directions.Select(d => Go(d)).ToArray();

    public string[] Go(string input)
    {
        var dirs = DirectionParser.Parse(input);
        return Go(dirs);
    }


    public abstract int Power { get; }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
}
