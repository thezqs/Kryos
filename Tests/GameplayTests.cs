using Core.Game;
using Core.Tools;
using Core.Game.Nodes;

namespace Tests;

public partial class GameplayTest : TestScene
{
    public GameplayTest()
    {
        Gameplay gameplay = new Gameplay();
        Add(gameplay);
    }
}
