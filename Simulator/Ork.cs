namespace Simulator;

public class Orc : Creature
{
    private int rage = 1;
    private int rage_buildup = 0;
    public int Rage
    {
        get => rage;
        init => rage = Math.Clamp(value, 1, 10);
    }
    public void Hunt()
    {
        Console.WriteLine($"{Name} is hunting.");
        rage_buildup++;
        if (rage_buildup >= 3)
        {
            rage = Math.Clamp(rage + 1, 1, 10);
            rage_buildup = 0;
        }
    }

    public Orc() { }

    public Orc(string name, int level, int rage) : base(name, level)
    {
        Rage = rage;
    }
    public override void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, level {Level} rage {Rage}.");
    }
    public override int Power => 7 * Level + 3 * Rage;
}