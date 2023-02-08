using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace UserSearch.Services;

public class XmlSerializationService : ISerializationService
{
    public void ExportToFile<T>(T obj, string path, Encoding encoding)
    {
        using var file = new StreamWriter(path, false, encoding);
        file.Write(ExportToString(obj));
    }
    public void ExportToFile<T>(T obj, string path) => ExportToFile(obj, path, Encoding.UTF8);

    public string ExportToString<T>(T obj)
    {

        var serializer = new XmlSerializer(typeof(T));
        using var stringWriter = new StringWriter();
        serializer.Serialize(stringWriter, obj);
        return stringWriter.ToString();
    }


    public T ImportFromFile<T>(string path, Encoding encoding)
    {
        using var file = new StreamReader(path, encoding);
        return ImportFromString<T>(file.ReadToEnd());
    }

    public T ImportFromFile<T>(string path) => ImportFromFile<T>(path, Encoding.UTF8);
    public T ImportFromString<T>(string serializedObj)
    {
        var serializer = new XmlSerializer(typeof(T));
        using var stringWriter = new StringReader(serializedObj);
        return (T)serializer.Deserialize(stringWriter);
    }
}