using Data.Game.Nodes;

namespace Data.Game;

public record struct BpmPoint(float Time, float Bpm);

public record struct InstantiateEvent(float StartTime, NodeData NodeToAdd);

public record ChartGameplay(BpmPoint[] Bpm, InstantiateEvent[] Instantiate);
