using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;

namespace JsonAsserts.Tests;

public abstract class TestsBase
{
    protected readonly Serializer serializer = new Serializer();

    protected async Task<string> LoadJson(string filename)
    {
        var path = Path.Combine(
            TestContext.CurrentContext.TestDirectory,
            "Resources",
            filename);

        return await File.ReadAllTextAsync(path);
    }
}
