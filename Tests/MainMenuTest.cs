using osu.Framework.Allocation;
using osu.Framework.Testing;
using osu.Framework.Screens;
using Core.UserInterface;

namespace Tests;

public partial class MainMenuTest : TestScene
{
    private ScreenStack screenStack = null!;

    public MainMenuTest()
    {
        Child = screenStack = new ScreenStack();
        screenStack.Push(new Main());
    }
}
