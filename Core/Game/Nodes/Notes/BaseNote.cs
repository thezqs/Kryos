namespace Core.Game.Nodes.Notes;

public abstract partial class BaseNote : Node
{
    protected readonly BindableColour4 CenterColour = new(Color4.White);
    protected new readonly BindableColour4 BorderColour = new(Color4.Black);

    protected BaseNote()
    {
        
    }
}
