namespace Data.Game.Animations;

/// <summary>
/// Contiene la informacion de un momento exacto que en el juego se anima.
/// </summary>
public readonly struct KeyFrame<T>(float time, T value, float ease = 1.0f)
{
    public float Time { get; init; } = time;

    public T Value { get; init; } = value;

    /// <summary>
    /// Controla el Easing:
    /// 0 -> Constante.
    /// 1 -> Linal.
    /// Mayor de 1 -> Ease-out. 
    /// Entre 0 y 1 -> Ease-in. 
    /// Negativo -> In-out / Out-in.
    /// </summary>
    public float Ease { get; init; } = ease;
}
