using Core.Game;
using Core.Game.Nodes;

namespace Tests;

public partial class GameplayTest : TestScene
{
    public GameplayTest()
    {
        Gameplay gameplay = new Gameplay();
        Add(gameplay);

        gameplay.AddNode(new Node());
    }
}
