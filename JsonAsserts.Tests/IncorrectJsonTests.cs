using FluentAssertions;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace JsonAsserts.Tests;

[TestFixture]
public class IncorrectJsonTests : TestsBase
{
    [Test]
    public async Task ComparingDeserializedModelsDoesntDetectExtraFields()
    {
        var expectedJson = await LoadJson("TooManyFields.json");
        var expectedModel = serializer.Deserialize(expectedJson);

        var actualModel = new Model
        {
            Field1 = "1",
            Field2 = "2",
            Field3 = "3",
        };

        actualModel.Should().BeEquivalentTo(expectedModel);
    }

    [Test]
    public async Task WithoutCorrectImportIncorrectFieldsArentDetected()
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

        actual.Should().BeEquivalentTo(expected);
    }
}