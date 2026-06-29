using Data.Game;
using Data.Game.Nodes;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Core.Tools;

public static partial class ChartTools
{
    private static readonly Dictionary<string, Type?> type_cache = new(StringComparer.OrdinalIgnoreCase);

    private static readonly JsonSerializerOptions json_options = new()
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true,
    };

    public static ChartMetadata? ReadMetadataChart(Stream stream)
    {
        try
        {
            ChartMetadata? metadata = JsonSerializer.Deserialize<ChartMetadata>(stream, json_options);
            return metadata;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Error al deserializar JSON: {ex.Message}");
            return null;
        }
    }

    public static ChartGameplay? ReadGameplayChart(Stream stream)
    {
        if (stream == null || stream.Length == 0)
            return null;

        using var document = JsonDocument.Parse(stream);
        var root = document.RootElement;

        if (root.ValueKind != JsonValueKind.Object)
            return null;

        // Seccion de BPM.
        BpmPoint[]? bpmPoints = null;
        if (root.TryGetProperty("bpm", out JsonElement bpmArray))
        {
            bpmPoints = parseBpm(bpmArray);

            if (!bpmPoints.Any(p => p.Bpm > 0))
            {
                Console.WriteLine("❗ERROR: El campo 'bpm' no tiene puntos o todos los puntos estan dañados.");
                return null;
            }
        }
        else
        {
            Console.WriteLine($"❗ERROR: No se ha encontrado el parametro 'bpm' en el chart.");
            return null;
        }

        // Seccion InstantiateEvents.
        InstantiateEvent[] instantiateEvents = [];
        if (root.TryGetProperty("instantiate", out JsonElement eventsArray) && eventsArray.ValueKind == JsonValueKind.Array)
        {
            instantiateEvents = parseInstantiateEvents(eventsArray);
        }
        else
        {
            Console.WriteLine("❗ERROR: No se pudo encontrar el campo 'instantiate' en el chart.");
            return null;
        }

        return new ChartGameplay(bpmPoints, instantiateEvents);
    }

    private static BpmPoint[] parseBpm(JsonElement bpmArray)
    {
        int length = bpmArray.GetArrayLength();
        BpmPoint[] bpmPoints = new BpmPoint[length];

        for (int i = 0; i < length; i++)
        {
            JsonElement item = bpmArray[i];

            try
            {
                float time = item.GetProperty("time").GetSingle();
                float bpm = item.GetProperty("bpm").GetSingle();

                if (bpm < 60)
                {
                    Console.WriteLine($"⚠️ Warning: No se ha podido parsear en el indice {i}: El Bpm es menor a 60. Omitiendo.");
                    continue;
                }

                bpmPoints[i] = new BpmPoint { Time = time, Bpm = bpm };
            }
            catch
            {
                Console.WriteLine($"⚠️ Warning: No se ha podido parsear en el indice {i}: Los campos bpm o time no estan disponibles o estan dañados. Omitiendo.");
                Console.WriteLine(item);
            }
        }
        return bpmPoints;
    }

    private static InstantiateEvent[] parseInstantiateEvents(JsonElement instantiateArray)
    {
        List<InstantiateEvent> flatTimeline = [];

        if (instantiateArray.ValueKind == JsonValueKind.Array)
        {
            var stack = new Stack<(JsonElement Element, NodeData? Parent)>();

            foreach (JsonElement root in instantiateArray.EnumerateArray())
            {
                stack.Push((root, null));
            }

            while (stack.Count > 0)
            {
                var (element, parent) = stack.Pop();
                InstantiateEvent? evt = ParseEvent(element, parent);
                if (evt == null) continue;

                flatTimeline.Add(evt.Value);

                if (element.TryGetProperty("childs", out JsonElement childsArray) && childsArray.ValueKind == JsonValueKind.Array)
                {
                    foreach (JsonElement child in childsArray.EnumerateArray())
                    {
                        stack.Push((child, evt.Value.NodeToAdd));
                    }
                }
            }
        }

        flatTimeline.Sort((a, b) => a.StartTime.CompareTo(b.StartTime));

        return [.. flatTimeline];
    }

    public static InstantiateEvent? ParseEvent(JsonElement element, NodeData? parent = null)
    {
        string? type = null;

        // Obtenemos el tipo
        if (element.TryGetProperty("type", out JsonElement typeElement))
        {
            if (typeElement.ValueKind == JsonValueKind.String)
            {
                type = typeElement.GetString()?.Trim();

                if (type != null && !MyRegex().IsMatch(type))
                {
                    type = null;
                }
            }
        }

        if (type == null)
        {
            Console.WriteLine($"⚠️ Warning: El campo 'type'no se encontro o es invalido. Omitiendo Nodo: {element}");
            return null;
        }

        string classNameTarget = $"{type}Data";

        if (!type_cache.TryGetValue(classNameTarget, out Type? targetType))
        {
            targetType = typeof(NodeData).Assembly.GetTypes().FirstOrDefault(
                t =>
                    t.Name.Equals(classNameTarget, StringComparison.OrdinalIgnoreCase) &&
                    t.Namespace != null &&
                    t.Namespace.StartsWith("Data.Game.Nodes", StringComparison.Ordinal));

            type_cache[classNameTarget] = targetType;
        }

        // Validaciones
        if (targetType == null)
        {
            Console.WriteLine($"⚠️ Warning: El tipo de nodo '{type}Data' no existe. Omitiendo Nodo: {element}");
            return null;
        }
        if (!typeof(NodeData).IsAssignableFrom(targetType))
        {
            Console.WriteLine($"⚠️ Warning: El tipo '{targetType.Name}' existe pero no hereda de NodeData.  Omitiendo Nodo: {element}");
            return null;
        }

        // Obtenemos el tiempo
        float time = float.NegativeInfinity;

        if (element.TryGetProperty("startTime", out JsonElement timeElement))
        {
            if (timeElement.ValueKind == JsonValueKind.Number)
            {
                time = timeElement.GetSingle();
            }
        }

        if (!float.IsFinite(time))
        {
            Console.WriteLine($"⚠️ Warning: El campo 'time' no se encontro o es invalido. Omitiendo Nodo: {element}");
            return null;
        }

        NodeData? nodeData = null;

        try
        {
            nodeData = JsonSerializer.Deserialize(element, targetType, json_options) as NodeData;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"⚠️ Warning: Error de casteo o formato JSON al deserializar {targetType.Name}: {ex.Message}.  Omitiendo Nodo: {element}");
            return null;
        }

        if (nodeData == null)
        {
            Console.WriteLine($"⚠️ Warning: Hubo un error al serializar el nodo.  Omitiendo Nodo: {element}");
            return null;
        }

        nodeData.Parent = parent;

        return new(time, nodeData);
    }

    // Para el regex en ParseEvent.
    [GeneratedRegex(@"^[a-zA-Z0-9_]+$")]
    private static partial Regex MyRegex();

}
