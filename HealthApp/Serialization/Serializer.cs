using System.Text.Json;
using System.Xml.Serialization;

namespace Serialization;
public class Serializer : ISerializer
{
    public void SerializeJson<T>(IEnumerable<T> collection, string fileName, JsonSerializerOptions? options = null)
    {
        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
        {
            JsonSerializer.Serialize(fs, collection, options);
        }
    }

    public IEnumerable<T>? DeserializeJson<T>(string fileName)
    {
        if (!File.Exists(fileName))
        {
            return null;
        }
        return JsonSerializer.Deserialize<IEnumerable<T>>(File.ReadAllText(fileName));
    }

    public void SerializeXml<T>(IEnumerable<T> collection, string fileName)
    {
        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
        {
            XmlSerializer xmlSerializer = new(collection.GetType());
            xmlSerializer.Serialize(fs, collection);
        }
    }

    public IEnumerable<T>? DeserializeXml<T>(string fileName)
    {
        if (!File.Exists(fileName))
        {
            return null;
        }
        using (FileStream fs = File.OpenRead(fileName))
        {
            XmlSerializer xmlSerializer = new(typeof(IEnumerable<T>));
            return (IEnumerable<T>?)xmlSerializer.Deserialize(fs);
        }

    }

}