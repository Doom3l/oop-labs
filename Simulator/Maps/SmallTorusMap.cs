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
