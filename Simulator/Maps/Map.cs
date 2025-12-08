namespace Simulator.Maps;

public abstract class Map

{
    protected readonly Dictionary<Point, List<Creature>> _entities = new();

    public int SizeX { get; }
    public int SizeY { get; }

    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5 || sizeY < 5)
            throw new ArgumentOutOfRangeException("Min size is 5");
        SizeX = sizeX;
        SizeY = sizeY;
    }
    protected readonly Dictionary<Point, List<Creature>> entities =
    new();

    protected void AddEntity(Creature c, Point p)
    {
        if (!entities.ContainsKey(p))
            entities[p] = new List<Creature>();

        entities[p].Add(c);
    }


    public abstract bool Exist(Point p);
    public abstract Point Next(Point p, Direction d);
    public abstract Point NextDiagonal(Point p, Direction d);
    public abstract void Add(Creature creature, Point point);
    public abstract void Remove(Creature creature, Point point);
    public abstract void Move(Creature creature, Point from, Point to);
    public abstract IEnumerable<Creature> At(Point point);
    public IEnumerable<Creature> At(int x, int y) => At(new Point(x, y));

}
