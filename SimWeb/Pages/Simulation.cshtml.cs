using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator;
using Simulator.Maps;
using Simulator.Obstacles;

namespace SimWeb.Pages;

public class SimulationModel : PageModel
{
    private const string TurnKey = "Turn";

    public SimulationLog Log { get; private set; } = null!;
    public TurnLog CurrentTurn { get; private set; } = null!;
    public int TurnIndex { get; private set; }

    public void OnGet()
    {
        InitSimulation();
    }

    public void OnPostNext()
    {
        InitSimulation();
        TurnIndex = Math.Min(TurnIndex + 1, Log.TurnLogs.Count - 1);
        SaveTurn();
        CurrentTurn = Log.TurnLogs[TurnIndex];
    }

    public void OnPostPrevious()
    {
        InitSimulation();
        TurnIndex = Math.Max(TurnIndex - 1, 0);
        SaveTurn();
        CurrentTurn = Log.TurnLogs[TurnIndex];
    }

    private void InitSimulation()
    {
        SmallTorusMap map = new(8, 6);

        //dodanie przeszkody
        map.AddObstacle(new Rock(new Point(6, 1)));
        map.AddObstacle(new Rock(new Point(4, 3)));
        map.AddObstacle(new Rock(new Point(2, 3)));



        List<IMappable> creatures =
        [
            new Elf("Elrond"),
            new Orc("Azog", 2, 3),
            new Animals { Description = "Rabbits" },
            new Birds { Description = "Eagles", CanFly = true },
            new Birds { Description = "Ostriches", CanFly = false }
        ];

        List<Point> points =
        [
            new(1, 1),
            new(2, 2),
            new(3, 3),
            new(4, 1),
            new(6, 4)
        ];

        string moves = "udlrudlrudlrudlrudlr";

        Simulation simulation = new(map, creatures, points, moves);
        Log = new SimulationLog(simulation);

        TurnIndex = HttpContext.Session.GetInt32(TurnKey) ?? 0;
        CurrentTurn = Log.TurnLogs[TurnIndex];
    }

    private void SaveTurn()
    {
        HttpContext.Session.SetInt32(TurnKey, TurnIndex);
    }
}
