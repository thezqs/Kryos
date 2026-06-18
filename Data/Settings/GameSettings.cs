using System.Numerics;

namespace Data.Settings;

/// <summary> La clase encargada de guardar las configuraciones el juego. </summary>
public class GameSettings
{
    /// <summary> Fuerza la resolucion a Resolution </summary>
    public bool ForceResolution = false;

    /// <summary>
    /// La resolucion de todos los mapas.
    /// Solo funciona si ForceResolution True.
    /// </summary>
    public Vector2 Resolution = new(1366, 768);

}
