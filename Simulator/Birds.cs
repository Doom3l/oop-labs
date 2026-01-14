namespace Simulator;

public class Birds : Animals
{
    public bool CanFly { get; set; } = true;

    public override char Symbol => CanFly ? 'B' : 'b';

    public override void Go(Direction direction)
    {
        base.Go(direction);
    }

    public override string Info
    {
        get
        {
            string flyInfo = CanFly ? "fly+" : "fly-";
            return $"{Description} ({flyInfo}) <{Size}>";
        }
    }
}
