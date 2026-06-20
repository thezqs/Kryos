using Core.UserInterface.Components.Buttons;

namespace Tests;

public partial class KryosButtonTest : TestScene
{
    [BackgroundDependencyLoader]
    private void Load()
    {
        Child = new FillFlowContainer()
        {
            Direction = FillDirection.Horizontal,

            Children = new Drawable[]
            {
                new TextButton("Prueba", () => Console.WriteLine("¡Clic!"))
                {
                    Origin = Anchor.TopLeft,
                    Anchor = Anchor.TopLeft,
                },
                new IconButton(FontAwesome.Solid.Play, () => Console.WriteLine("¡Clic!"))
                {
                    Origin = Anchor.TopLeft,
                    Anchor = Anchor.TopLeft,
                    ToggleMode = true
                },
            },
        };
    }
}
