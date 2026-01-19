using Simulator.Maps;

namespace Simulator;

public class SimulationLog
{
    private Simulation _simulation { get; }

    public int SizeX { get; }
    public int SizeY { get; }

    public List<TurnLog> TurnLogs { get; } = [];

    public SimulationLog(Simulation simulation)
    {
        _simulation = simulation
            ?? throw new ArgumentNullException(nameof(simulation));

        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;

        Run();
    }

    private void Run()
    {
        SaveTurn(); 

        while (!_simulation.Finished)
        {
            _simulation.Turn(); 
            SaveTurn();         
        }
    }

    private void SaveTurn()
    {
        var symbols = CaptureSymbols();

        var health = _simulation.Creatures
            .OfType<IFightable>()
            .ToDictionary(
                f => f.GetType().Name,
                f => f.Health
            );

        TurnLogs.Add(new TurnLog
        {
            Mappable = _simulation.CurrentCreature?.ToString() ?? "",
            Move = _simulation.CurrentMoveName ?? "",
            Symbols = symbols,
            Health = health
        });
    }

    private Dictionary<Point, char> CaptureSymbols()
    {
        Dictionary<Point, char> symbols = new();

        for (int i = 0; i < _simulation.Creatures.Count; i++)
        {
            var p = _simulation.Positions[i];
            var c = _simulation.Creatures[i];

            if (!symbols.ContainsKey(p))
                symbols[p] = c.Symbol;
            else
                symbols[p] = 'X';
        }

        return symbols;
    }
}
