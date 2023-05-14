using System.Text.Json;

namespace Serialization;

public interface ISerializer
{
    void SerializeJson<T>(IEnumerable<T> collection, string fileName, JsonSerializerOptions? options = null);
    void SerializeXml<T>(IEnumerable<T> collection, string fileName);
    IEnumerable<T>? DeserializeJson<T>(string fileName);
    IEnumerable<T>? DeserializeXml<T>(string fileName);
}
