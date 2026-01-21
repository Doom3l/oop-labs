using Simulator;

namespace Simulator.Obstacles;

public interface IObstacle
{
    bool Blocks(Point p);
    char Symbol { get; }
}
