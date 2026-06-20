namespace Core.UserInterface.Components.Buttons;

public partial class TextButton : BaseButton
{
    public readonly SpriteText TextComponent;

    public TextButton(string text, Action ClicAction)
    {
        Masking = true;
        CornerRadius = 20;
        AddInternal(TextComponent = new SpriteText
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Text = text,
            Font = FrameworkFont.Regular.With(size: 20),
            Colour = Color4.White
        }
        );

        TextComponent.Text = text;
        Action = ClicAction;

        Size = new Vector2(150, 40);
        BackgroundColour = Color4.RoyalBlue;

        Origin = Anchor.Centre;
        Anchor = Anchor.Centre;
    }

}
