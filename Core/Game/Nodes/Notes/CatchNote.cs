namespace Core.Game.Nodes.Notes;

public partial class CatchNote : BaseNote
{
    public CatchNote()
    {
        Circle outerCircle;
        Circle centerCircle;

        InternalChildren =
        [
            outerCircle = new()
            {
                Size = new(60, 60),
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
            },
            centerCircle = new()
            {
                Size = new(50, 50), Anchor =
                Anchor.Centre,
                Origin = Anchor.Centre,
            },
        ];

        BorderColour.BindValueChanged(
            c => outerCircle.Colour = c.NewValue, runOnceImmediately: true);
        CenterColour.BindValueChanged(
            c => centerCircle.Colour = c.NewValue, runOnceImmediately: true);
    }
}
