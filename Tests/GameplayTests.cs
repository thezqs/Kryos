using Core.Game;
using Core.Tools;
using Core.Game.Nodes;

namespace Tests;

public partial class GameplayTest : TestScene
{
    public GameplayTest()
    {
        var file = FileTools.GetResourceFile("DefaultCharts/TestChart/Gameplay.json");
        var gameplay = ChartTools.ReadGameplayChart(file);
        
        foreach (var evt in gameplay.Instantiate)
        {
            Console.WriteLine($"Time: {evt.StartTime}, Node: {evt.NodeToAdd}");
        }
    }
}
