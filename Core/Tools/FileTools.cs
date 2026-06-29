using osu.Framework.IO.Stores;
using System.Reflection;

namespace Core.Tools;

public static class FileTools
{
    public static Stream? GetResourceFile(string path)
    {
        Assembly resourceAssembly = typeof(Resources.ResourceMarker).Assembly;
        DllResourceStore resourceStore = new DllResourceStore(resourceAssembly);

        Stream? stream = resourceStore.GetStream(path);
        if (stream == null)
        {
            Console.WriteLine($"Recurso '{path}' no encontrado.");
            return null;
        }

        return stream;
    }


}
