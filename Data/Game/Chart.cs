using System.Numerics;

namespace Data.Game;

/// <summary> La clase donde se guardan todos los datos de un Chart </summary>
public class Chart
{
    /// <summary> 
    /// La resolucion del mapa. 
    /// Puede ser ignorada si GameSettings.ForceResolution es true
    /// </summary>
    public Vector2 Resolution { get; set; } = new();
    
    public List<ObjectData> Objects { get; set; } = [];
}
