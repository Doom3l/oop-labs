using Simulator;

namespace Simulator.Obstacles;

public class Rock : IObstacle
{
    public Point Position { get; }

    public Rock(Point position)
    {
        Position = position;
    }

    public bool Blocks(Point p)
    {
        return p.Equals(Position);
    }

    public char Symbol => '#';
}
