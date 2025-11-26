namespace Simulator;

public class Elf : Creature
{
    private int agility_buildup = 0;
    private int agility = 1;
    public int Agility 
    {
        get => agility;
        init => agility = Validator.Limiter(value, 1, 10);
    }
    public void Sing()
    {
        Console.WriteLine($"{Name} is singing.");
        agility_buildup++;
        if (agility_buildup >= 3)
        {
            agility = Validator.Limiter(agility + 1, 1, 10);
            agility_buildup = 0;
        }
    }

    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }
    public Elf() { }
    public override void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, level {Level} agility {Agility}.");
    }

    public override string ToString()
    {
        return $"Hi, I'm {Name}, level {Level} agility {Agility}.";
    }

    public override int Power => 8 * Level + 2 * Agility;
}
