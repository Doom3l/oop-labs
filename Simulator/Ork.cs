namespace Simulator;

public class Orc : Creature
{
    private int rage = 1;
    private int rage_buildup = 0;
    public int Rage
    {
        get => rage;
        init => rage = Validator.Limiter(value, 0, 10);
    }
    public void Hunt()
    {
        rage_buildup++;
        if (rage_buildup >= 3)
        {
            rage = Validator.Limiter(rage + 1, 0, 10);
            rage_buildup = 0;
        }
    }

    public Orc() { }

    public Orc(string name, int level, int rage) : base(name, level)
    {
        Rage = rage;
    }
    public override string Greetings()
    {
        return $"Hi, I'm {Name}, level {Level} rage {Rage}.";
    }
    public override int Power => 7 * Level + 3 * Rage;

    public override string Info => $"{Name}, [{Level}], [{Rage}]";
}