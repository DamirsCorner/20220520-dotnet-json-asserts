using FluentAssertions;
using FluentAssertions.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace JsonAsserts.Tests;

[TestFixture]
public class CorrectJsonTests : TestsBase
{
    [Test]
    public async Task JsonAssertionsDetectTooManyFields()
    {
        var expectedJson = await LoadJson("TooManyFields.json");
        var expected = JToken.Parse(expectedJson);

        var actualModel = new Model
        {
            Field1 = "1",
            Field2 = "2",
            Field3 = "3",
        };
        var actualJson = serializer.Serialize(actualModel);
        var actual = JToken.Parse(actualJson);

        actual.Should().NotBeEquivalentTo(expected);
    }

    [Test]
    public async Task JsonAssetionsDetectIncorrectFields()
    {
        var expectedJson = await LoadJson("IncorrectFields.json");
        var expected = JToken.Parse(expectedJson);

        var actualModel = new Model
        {
            Field1 = "1",
            Field2 = "2",
            Field3 = "3",
        };
        var actualJson = serializer.Serialize(actualModel);
        var actual = JToken.Parse(actualJson);

        actual.Should().NotBeEquivalentTo(expected);
    }
}
