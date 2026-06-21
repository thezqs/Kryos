using System.Reflection;

namespace Tests;

public static class Program
{
    public static void Main()
    {
        using GameHost host = Host.GetSuitableDesktopHost("Tests");
        host.Run(new Test());
    }
}

public partial class Test : Game
{
    protected override void LoadComplete()
    {
        base.LoadComplete();

        Add(new TestBrowser(Assembly.GetExecutingAssembly().GetName().Name));
    }
}
