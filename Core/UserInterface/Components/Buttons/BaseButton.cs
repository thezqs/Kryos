namespace Core.UserInterface.Components.Buttons;

public abstract partial class BaseButton : Button
{
    public bool ToggleMode { get; set; } = false;
    public readonly BindableBool Pressed = new();

    private readonly Box backgroundComponent;

    private Color4 colorAfterClick = Color4.White;

    public Color4 BackgroundColour
    {
        get => backgroundComponent.Colour;
        set => backgroundComponent.Colour = value;
    }

    public BaseButton()
    {
        Masking = true;
        CornerRadius = 20;

        AddInternal(backgroundComponent = new Box
        {
            RelativeSizeAxes = Axes.Both,
        });

    }

    protected override bool OnHover(HoverEvent e)
    {
        this.FadeColour(Color4.LightGray, 100);
        colorAfterClick = Color4.LightGray;

        return base.OnHover(e);
    }

    protected override void OnHoverLost(HoverLostEvent e)
    {
        Color4 toColor = Pressed.Value ? Color4.DarkGray : Color4.White;
        this.FadeColour(toColor, 100);
        colorAfterClick = Color4.White;

        base.OnHoverLost(e);
    }

    protected override bool OnMouseDown(MouseDownEvent e)
    {
        this.FadeColour(Color4.Gray, 50);
        return true;
    }

    protected override void OnMouseUp(MouseUpEvent e)
    {
        // Retornamos ya que el usuario queria cancelar el click.
        if (!IsHovered) return;

        if (ToggleMode)
        {
            Pressed.Value = !Pressed.Value;
            this.FadeColour(Pressed.Value ? Color4.DarkGray : colorAfterClick, 50);
        }
        else this.FadeColour(colorAfterClick, 50);
    }

}
