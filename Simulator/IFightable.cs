namespace Simulator;

public interface IFightable
{
    int Health { get; }
    bool IsAlive { get; }

    void TakeDamage(int damage);
}
