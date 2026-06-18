using osu.Framework.Allocation;
using osu.Framework.Testing;
using Core.UserInterface;

namespace Tests;

public partial class TestSceneMiComponente : TestScene
{
    public TestSceneMiComponente()
    {
    }
    
    [BackgroundDependencyLoader]
    private void load()
    {
        Child = new Main();
    }
}
