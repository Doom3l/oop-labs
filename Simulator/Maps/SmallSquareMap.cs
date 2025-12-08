using Simulator;

namespace Simulator.Maps;

public class SmallSquareMap : Map
{
    public int Size { get; }

    private readonly Rectangle rect;

    public SmallSquareMap(int size)
    {
        if (size < 5 || size > 20)
            throw new ArgumentOutOfRangeException(nameof(size));

        Size = size;
        rect = new Rectangle(0, 0, size - 1, size - 1);
    }

    public override bool Exist(Point p)
        => rect.Contains(p);

    public override Point Next(Point p, Direction d)
    {
        var np = p.Next(d);
        return Exist(np) ? np : p;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        var np = p.NextDiagonal(d);
        return Exist(np) ? np : p;
    }
}
