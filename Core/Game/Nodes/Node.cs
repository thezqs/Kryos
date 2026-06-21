namespace Core.Game.Nodes;

public partial class Node : CompositeDrawable
{
    protected override void Update()
    {
        Vector2 gameSize = Gameplay.GameSize;

        if (gameSize == Vector2.Zero) return;

        // Primera prueba
        Position = gameSize / 2;
    }

    public void AddChild(Node node)
    {
        AddInternal(node);
    }
}
