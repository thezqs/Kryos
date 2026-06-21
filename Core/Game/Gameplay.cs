using Core.Game.Nodes;

namespace Core.Game;

public partial class Gameplay : CompositeDrawable
{
    public static Vector2 GameSize { get; private set; } = Vector2.Zero;

    public Gameplay()
    {
        // El Gameplay se ejecuta en toda la pantalla.
        RelativeSizeAxes = Axes.Both;
        Size = new Vector2(1f, 1f);
    }

    protected override void Update()
    {
        GameSize = DrawSize;
    }

    public void AddNode(Node node)
    {
        AddInternal(node);
    }
}
