namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public SmallTorusMap(int sizeX, int sizeY)
        : base(sizeX, sizeY)
    {
        if (sizeX > 20 || sizeY > 20)
            throw new ArgumentOutOfRangeException();
    }

    public override bool Exist(Point p)
        => true; // torus zawsze istnieje

    public override Point Next(Point p, Direction d)
    {
        var np = p.Next(d);
        return new Point(
            (np.X + SizeX) % SizeX,
            (np.Y + SizeY) % SizeY
        );
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        var np = p.NextDiagonal(d);
        return new Point(
            (np.X + SizeX) % SizeX,
            (np.Y + SizeY) % SizeY
        );
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
