namespace Core.UserInterface.Components;

public partial class Spacer : Container
{
    public Spacer()
    {
        RelativeSizeAxes = Axes.Both;

        Size = new Vector2(1f);
    }
}
