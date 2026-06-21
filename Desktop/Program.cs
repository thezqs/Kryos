using osu.Framework.Platform;
using osu.Framework;
using Core;

namespace Desktop;

public static class Program
{
    public static void Main(string[] args)
    {
        using GameHost host = Host.GetSuitableDesktopHost(@"Kryos");
        using osu.Framework.Game game = new Engine();

        host.Run(game);
    }
}
