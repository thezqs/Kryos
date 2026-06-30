using Core.Data.Game.Nodes;

namespace Core.Data.Game;

public record struct BpmPoint(float Time, float Bpm);

public record struct InstantiateEvent(float StartTime, NodeData NodeToAdd);

public record ChartGameplay(BpmPoint[] Bpm, InstantiateEvent[] Instantiate);
