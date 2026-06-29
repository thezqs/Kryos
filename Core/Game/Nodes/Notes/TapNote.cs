namespace Core.Game.Nodes.Notes;

public partial class TapNote : BaseNote
{
    public TapNote()
    {
        Circle outerCircle;
        Circle centerCircle;
        Circle innerCircle;

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
            innerCircle = new()
            {
                Size = new(30, 30),
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
            },
        ];

        BorderColour.BindValueChanged(
            c => outerCircle.Colour = innerCircle.Colour = c.NewValue, runOnceImmediately: true);
        CenterColour.BindValueChanged(
            c => centerCircle.Colour = c.NewValue, runOnceImmediately: true);
    }
}
