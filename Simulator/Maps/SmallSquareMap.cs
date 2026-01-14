using Simulator;

namespace Simulator.Maps;

public class SmallSquareMap : Map
{
    public SmallSquareMap(int size)
        : base(size, size)
    {
        if (size > 20)
            throw new ArgumentOutOfRangeException();
    }

    public override bool Exist(Point p)
        => p.X >= 0 && p.X < SizeX &&
           p.Y >= 0 && p.Y < SizeY;

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

    public override void Add(IMappable entity, Point point)
    {
        if (!entities.ContainsKey(point))
            entities[point] = new List<IMappable>();

        entities[point].Add(entity);
    }

    public override void Remove(IMappable entity, Point point)
    {
        if (entities.ContainsKey(point))
            entities[point].Remove(entity);
    }

    public override void Move(IMappable entity, Point from, Point to)
    {
        Remove(entity, from);
        Add(entity, to);
    }

    public override IEnumerable<IMappable> At(Point point)
    {
        if (!entities.ContainsKey(point))
            return Enumerable.Empty<IMappable>();

        return entities[point];
    }
}
