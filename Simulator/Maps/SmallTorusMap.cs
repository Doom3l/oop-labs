using Simulator;

namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public int Size { get; }

    public SmallTorusMap(int size)
    {
        if (size < 5 || size > 20)
            throw new ArgumentOutOfRangeException(nameof(size));

        Size = size;
    }

    public override bool Exist(Point p)
    {
        return p.X >= 0 && p.X < Size &&
               p.Y >= 0 && p.Y < Size;
    }

    public override Point Next(Point p, Direction d)
    {
        var np = p.Next(d);

        return new Point(
            (np.X + Size) % Size,
            (np.Y + Size) % Size
        );
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        var np = p.NextDiagonal(d);

        return new Point(
            (np.X + Size) % Size,
            (np.Y + Size) % Size
        );
    }
}