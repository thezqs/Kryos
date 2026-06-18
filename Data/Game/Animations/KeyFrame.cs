namespace Data.Game.Animations;

/// <summary>
/// Contiene la informacion de un momento exacto que en el juego se anima.
/// </summary>
public readonly struct KeyFrame<T>(double time, T value, float ease)
{
    public double Time { get; init; } = time;

    public T Value { get; init; } = value;

    public float Ease { get; init; } = ease;
}
