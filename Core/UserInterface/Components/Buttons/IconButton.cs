namespace Core.UserInterface.Components.Buttons;

public partial class IconButton : BaseButton
{
    private readonly SpriteIcon iconComponent;

    public IconButton(IconUsage icon, Action ClicAction, bool backgroundUsed = true)
    {
        Size = new Vector2(40, 40);

        AddInternal(iconComponent = new SpriteIcon
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Size = new Vector2(20, 20)
        });

        iconComponent.Icon = icon;
        Action = ClicAction;

        Origin = Anchor.Centre;
        Anchor = Anchor.Centre;

        BackgroundColour = backgroundUsed ? Color4.RoyalBlue : Color4.Transparent;
    }
}
