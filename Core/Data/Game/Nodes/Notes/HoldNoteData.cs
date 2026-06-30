namespace Core.Data.Game.Nodes.Notes;

public record HoldNoteData : NoteData
{
    public override float EndTime { get; init; }
}
