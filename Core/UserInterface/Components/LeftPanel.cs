using Core.UserInterface.Components.Buttons;

namespace Core.UserInterface.Components;

public partial class LeftPanel : Container
{

    public LeftPanel()
    {
        Origin = Anchor.CentreLeft;
        Anchor = Anchor.CentreLeft;

        RelativeSizeAxes = Axes.Y;
        Height = 1f;
        Width = 45;
    }

    [BackgroundDependencyLoader]
    private void load()
    {
        Children =
            [
                new Box
            {
                RelativeSizeAxes = Axes.Both,
                Colour = Color4.Black
            },
            new FillFlowContainer
            {
                RelativeSizeAxes = Axes.Both,
                Direction = FillDirection.Vertical,
                Children =
                [
                    new IconButton(FontAwesome.Solid.Circle, () => Console.WriteLine("Clic"))
                    {}
                ]
            }
        ];
    }
}
