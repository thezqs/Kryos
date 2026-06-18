using Data.Game.Animations;

namespace Data.Game;

/// <summary> La base de cualquier objeto del juego en datos </summary>
public abstract class ObjectData
{
    ///<summary> El tiempo donde se crea el objeto </summary>
    public double Time;

    /// <summary> El tiempo donde el objeto se destruye </summary>
    public double EndTime;

    /// <summary> Los datos de la animacion </summary>
    public Animation AnimationData = new();
}
