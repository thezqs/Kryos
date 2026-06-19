namespace Core.UserInterface.Components.Buttons;

public abstract partial class BaseButton : Button
{
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
        this.FadeColour(Color4.White, 100);
        colorAfterClick = Color4.White;

        base.OnHoverLost(e);
    }

    protected override bool OnMouseDown(MouseDownEvent e)
    {
        this.FadeColour(Color4.Gray, 50);
        return base.OnMouseDown(e);
    }

    protected override void OnMouseUp(MouseUpEvent e)
    {
        this.FadeColour(colorAfterClick, 100);
    }

}
