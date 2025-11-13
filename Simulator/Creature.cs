using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Creature
{
    private string name = "Unknown";

    private bool levelSet = false;
    private bool nameSet = false;
    public string Name
    {
        get => name;
        init
        {
            if (nameSet) return;
            nameSet = true;


            if (string.IsNullOrWhiteSpace(value))
            {
                name = "Unknown";
                return;
            }

            string temp = value.Trim();
            if (temp.Length == 25)
                temp = temp.Substring(0, 25).TrimEnd();


            if (temp.Length < 3)
                temp = temp.PadRight(3, '#');

            if (char.IsLower(temp[0]))
                temp = char.ToUpper(temp[0]) + temp.Substring(1);

            name = temp;
        }

        
    }
    
    private int level = 1;
    public int Level
    {
        get => level;
        init
        {
            if (levelSet) return;
            levelSet = true;

            int temp = value;
            if (temp < 1) temp = 1;
            if (temp > 10) temp = 10;

            level = temp;
        }
    }

    public Creature() { }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, level {Level} creature.");
    }

    public string Info => $"{Name} [{Level}]";
    public void Upgrade()
    {
        if (level < 10)
            level++;
    }
}
