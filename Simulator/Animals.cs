using Simulator.Maps;

namespace Simulator;

public class Animals : IMappable
{
    public uint Size { get; set; } = 3;

    private string description = "Unknown";

    public required string Description
    {
        get => description;
        init => description = Validator.Shortener(value, 3, 25, '#');
    }

    public virtual string Info => $"{Description}, <{Size}>";

    public virtual char Symbol => 'A';

    public virtual void Go(Direction direction)
    {
    }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
}
