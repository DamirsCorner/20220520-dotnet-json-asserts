using System.Text;
using System.Text.Json;

namespace JsonAsserts;

public class Serializer
{
    public string Serialize(Model model)
    {
        return Encoding.UTF8.GetString(JsonSerializer.SerializeToUtf8Bytes(model));
    }

    public Model? Deserialize(string json)
    {
        return JsonSerializer.Deserialize<Model>(json);
    }
}
