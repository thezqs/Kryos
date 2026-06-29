namespace Data.Game.Animations;

/// <summary> 
/// Contiene toda la informacion de la pista de animacion de una variable.
/// </summary>
public record AnimationTrack<T>(KeyFrame<T>[] KeyFrames);