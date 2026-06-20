namespace Data.Game.Animations;

/// <summary>
/// Contiene la informacion de un momento exacto que en el juego se anima.
/// </summary>
public readonly struct KeyFrame<T>(double time, T value, bool isImmediate = false, float ease = 1.0f)
{
    public double Time { get; init; } = time;

    public T Value { get; init; } = value;

    /// <summary>
    /// Controla el Easing:
    /// 0 -> Constante
    /// 1 -> Linal.
    /// Mayor de 1 -> Ease-out. 
    /// Entre 0 y 1 -> Ease-in. 
    /// Negativo -> In-out / Out-in.
    /// </summary>
    public float Ease { get; init; } = ease;

    /// <summary>
    /// Si es true, no hay interpolacion y el valor se aplica imediatamente luego de Time
    /// </summary>
    public bool IsInmmediate { get; init; } = isImmediate;
}
