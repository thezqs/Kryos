using osu.Framework.Allocation;
using osu.Framework.Testing;
using Core.UserInterface;

namespace Tests;

public partial class MainMenu : TestScene
{
    public MainMenu()
    {
    }
    
    [BackgroundDependencyLoader]
    private void Load()
    {
        Child = new Main();
    }
}
