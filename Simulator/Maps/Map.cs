using Simulator.Obstacles;
using System.Linq;

namespace Simulator.Maps;

public abstract class Map
{
    protected readonly Dictionary<Point, List<IMappable>> entities = new();

    protected readonly List<IObstacle> obstacles = new();

    public int SizeX { get; }
    public int SizeY { get; }

    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5 || sizeY < 5)
            throw new ArgumentOutOfRangeException("Min size is 5");

        SizeX = sizeX;
        SizeY = sizeY;
    }

    protected void AddEntity(IMappable entity, Point p)
    {
        if (!entities.ContainsKey(p))
            entities[p] = new List<IMappable>();

        entities[p].Add(entity);
    }

    public void AddObstacle(IObstacle obstacle)
    {
        obstacles.Add(obstacle);
    }

    public bool IsBlocked(Point p)
    {
        return obstacles.Any(o => o.Blocks(p));
    }


    public abstract bool Exist(Point p);
    public abstract Point Next(Point p, Direction d);
    public abstract Point NextDiagonal(Point p, Direction d);

    public abstract void Add(IMappable entity, Point point);
    public abstract void Remove(IMappable entity, Point point);
    public abstract void Move(IMappable entity, Point from, Point to);

    public abstract IEnumerable<IMappable> At(Point point);
    public IEnumerable<IMappable> At(int x, int y) => At(new Point(x, y));
}
