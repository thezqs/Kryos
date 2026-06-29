namespace Data.Game.Animations;

/// <summary> 
/// La clase que contiene todos lo relacionado con la animacion de un objeto.
/// </summary> 
public class Animation(List<object> tracks)
{
    /// <summary>
    /// Los tracks de animacion.
    /// </summary>
    public List<object> Tracks { get; init; } = tracks;
}