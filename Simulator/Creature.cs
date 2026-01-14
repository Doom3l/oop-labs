using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public abstract class Creature : IMappable
{
    public abstract char Symbol { get; }
    private Map? map;
    private Point? position;

    public void Place(Map m, Point p)
    {
        map = m;
        position = p;
        m.Add(this, p);
    }

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
    public void Go(Direction d)
    {
        if (map == null || position == null)
            return;

        var newPos = map.Next(position.Value, d);
        map.Move(this, position.Value, newPos);
        position = newPos;
    }

    public abstract int Power { get; }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
}
