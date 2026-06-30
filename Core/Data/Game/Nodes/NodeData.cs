using Core.Data.Game.Animations;

namespace Core.Data.Game.Nodes;

// <summary> La base de cualquier objeto del juego en datos </summary>
public record NodeData
{
    // <summary> El tiempo donde se crea el objeto </summary>
    public float StartTime { get; init; }

    // <summary> El tiempo donde el objeto se destruye </summary>
    public virtual float EndTime { get; init; }

    // <summary> Los datos de la animacion </summary>
    public required Animation Animation { get; init; }

    public NodeData? Parent { get; set; }
}
