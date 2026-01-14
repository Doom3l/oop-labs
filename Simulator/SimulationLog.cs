using System.Drawing;
using Simulator.Maps;

namespace Simulator;

public class SimulationLog
{
    private Simulation _simulation { get; }

    public int SizeX { get; }
    public int SizeY { get; }

    public List<TurnLog> TurnLogs { get; } = [];

    // store starting positions at index 0
    public SimulationLog(Simulation simulation)
    {
        _simulation = simulation ??
            throw new ArgumentNullException(nameof(simulation));

        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;

        Run();
    }

    private void Run()
    {
        // ZAPIS STANU POCZĄTKOWEGO (tura 0)
        TurnLogs.Add(new TurnLog
        {
            Mappable = "",
            Move = "",
            Symbols = CaptureSymbols()
        });

        // kolejne tury
        while (!_simulation.Finished)
        {
            string mappable = _simulation.CurrentCreature.ToString();
            string move = _simulation.CurrentMoveName;

            _simulation.Turn();

            TurnLogs.Add(new TurnLog
            {
                Mappable = mappable,
                Move = move,
                Symbols = CaptureSymbols()
            });
        }
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
