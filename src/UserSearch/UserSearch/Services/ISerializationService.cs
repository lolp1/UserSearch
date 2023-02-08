using System.Text;

namespace UserSearch.Services;
/// <summary>
/// Simple interface providing methods for serializing/deserializing objects in common ways.
/// </summary>
public interface ISerializationService
{
    /// <summary>
    /// Serializes the specified object and writes the  document to the specified path.
    /// </summary>
    /// <typeparam name="T">The type of the object to serialize.</typeparam>
    /// <param name="obj">The object to serialize.</param>
    /// <param name="path">The path where the file is saved.</param>
    /// <param name="encoding">The encodi
    void ExportToFile<T>(T obj, string path, Encoding encoding);
    /// <summary>
    /// Serializes the specified object and writes the  document to the specified path using <see cref="Encoding.UTF8"/> encoding.
    /// </summary>
    /// <typeparam name="T">The type of the object to serialize.</typeparam>
    /// <param name="obj">The object to serialize.</param>
    /// <param name="path">The path where the file is saved.</param>
    string ExportToString<T>(T obj);
    /// <summary>
    /// Serializes the specified object and returns the  document.
    /// </summary>
    /// <typeparam name="T">The type of the object to serialize.</typeparam>
    /// <param name="obj">The object to serialize.</param>
    /// <returns> document of the serialized object.</returns>
    void ExportToFile<T>(T obj, string path);
    /// <summary>
    /// Deserializes the specified file into an object.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize.</typeparam>
    /// <param name="path">The path where the object is read.</param>
    /// <param name="encoding">The character encoding to use. </param>
    /// <returns>The deserialized object.</returns>
    T ImportFromFile<T>(string path, Encoding encoding);
    /// <summary>
    /// Deserializes the specified file into an object using <see cref="Encoding.UTF8"/> encoding.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize.</typeparam>
    /// <param name="path">The path where the object is read.</param>
    /// <returns>The deserialized object.</returns>
    T ImportFromString<T>(string serializedObj);
    /// <summary>
    /// Deserializes the  document to the specified object.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize.</typeparam>
    /// <param name="serializedObj">The string representing the serialized object.</param>
    /// <returns>The deserialized object.</returns>
    T ImportFromFile<T>(string path);
}
