namespace Core.Data.Game.Animations;

/// <summary>
/// Contiene la informacion de un momento exacto que en el juego se anima.
/// </summary>
public record struct KeyFrame<T>(float Time, T Value, float Ease = 1.0f);
