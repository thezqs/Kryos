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
    }

    [BackgroundDependencyLoader]
    private void Load()
    {
        // 1. Inicializamos el ScreenStack y lo añadimos como hijo del test
        Child = screenStack = new ScreenStack();

        // 2. Cargamos el menú principal dentro del stack
        screenStack.Push(new Main());
    }
}
