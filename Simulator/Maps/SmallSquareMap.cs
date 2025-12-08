using Simulator;

namespace Simulator.Maps;

public class SmallSquareMap : Map
{
    public SmallSquareMap(int size)
        : base(size, size)   // Square -> SizeX=SizeY
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

    public override void Add(Creature creature, Point point)
    {
        if (!_entities.ContainsKey(point))
            _entities[point] = new List<Creature>();

        _entities[point].Add(creature);
    }

    public override void Remove(Creature creature, Point point)
    {
        if (_entities.ContainsKey(point))
            _entities[point].Remove(creature);
    }

    public override void Move(Creature creature, Point from, Point to)
    {
        Remove(creature, from);
        Add(creature, to);
    }

    public override IEnumerable<Creature> At(Point point)
    {
        if (!_entities.ContainsKey(point))
            return Enumerable.Empty<Creature>();

        return _entities[point];
    }
}
