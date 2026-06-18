using osu.Framework.Allocation;
using osu.Framework.Screens;
using Core.UserInterface;

namespace Core;

public partial class Engine : osu.Framework.Game
{
    private ScreenStack screenStack = null!;

    [BackgroundDependencyLoader]
    private void load()
    {
        screenStack = new();
        Add(screenStack);  
    }

    protected override void LoadComplete()
    {
        screenStack.Push(new Main());
    }
}
