using Simulator;

public interface IMappable
{
    void Go(Direction direction);
    char Symbol { get; }
}
