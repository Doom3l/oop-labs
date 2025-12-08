namespace Simulator;

public class Birds : Animals
{
    public bool CanFly { get; set; } = true;

    public override string Info
    {
        get
        {
            string flyInfo = CanFly ? "fly+" : "fly-";
            return $"{Description} ({flyInfo}) <{Size}>";
        }
    }
}
