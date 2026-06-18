using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;

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

            new Container
            {
                Origin = Anchor.CentreLeft,
                Anchor = Anchor.CentreLeft,

                RelativeSizeAxes = Axes.Y,
                Height = 1f,
                Width = 35,

                Children =
                [
                    new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Colour = Color4.White
                    },
                ]
            },
        ];
    }
}
