namespace Core.UserInterface.Components.Buttons;

public partial class TextButton : BaseButton
{
    private readonly SpriteText textComponent;

    public TextButton(string text, Action ClicAction)
    {
        Masking = true;
        CornerRadius = 20;
        AddInternal(textComponent = new SpriteText
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Text = text,
            Font = FrameworkFont.Regular.With(size: 20),
            Colour = Color4.White
        }
        );

        textComponent.Text = text;
        Action = ClicAction;

        Size = new Vector2(150, 40);
        BackgroundColour = Color4.RoyalBlue;

        Origin = Anchor.Centre;
        Anchor = Anchor.Centre;
    }

}
