namespace Data.Game.Animations;

/// <summary> 
/// Contiene toda la informacion de la pista de animacion de una variable.
/// </summary>
public class AnimationTrack<T>(KeyFrame<T>[] keyFrames)
{
    /// <summary> 
    /// Los keyframes. NO EDITAR DIRECTAMENTE
    /// </summary>
    public KeyFrame<T>[] KeyFrames { get; init; } = keyFrames;

}