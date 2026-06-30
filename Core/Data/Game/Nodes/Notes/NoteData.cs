namespace Core.Data.Game.Nodes.Notes;

public abstract record NoteData : NodeData
{
    public float TapTime { get; init; }
    public override float EndTime => TapTime;
}
