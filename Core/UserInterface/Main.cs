using Core.UserInterface.Components;

namespace Core.UserInterface;

public partial class Main : Screen
{
    [BackgroundDependencyLoader]
    private void load()
    {
        InternalChildren =
        [

            new Box
            {
                RelativeSizeAxes = Axes.Both,
                Colour = Color4.DarkBlue,
            },
            new LeftPanel
            {
            }
        ];
    }
}
