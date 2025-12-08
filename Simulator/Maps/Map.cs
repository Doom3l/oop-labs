namespace Simulator.Maps;

public abstract class Map
{
    public abstract bool Exist(Point p);
    public abstract Point Next(Point p, Direction d);
    public abstract Point NextDiagonal(Point p, Direction d);
}
