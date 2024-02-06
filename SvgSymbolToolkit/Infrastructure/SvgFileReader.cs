using System.Xml;
using System.Xml.Serialization;

namespace SvgSymbolToolkit.Infrastructure
{
    public class SvgFileReader
    {
        /// <summary>
        /// Reads the given file and deserializes it as a model representing a SVG
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        /// <exception cref="XmlException"></exception>
        public static Task<Models.svg> ReadFromFile(string filePath)
        {
            using FileStream fileStream = File.OpenRead(filePath);

            XmlSerializer serializer = new(typeof(Models.svg));

            XmlReaderSettings settings = new()
            {
                Async = true
            };

            using XmlReader xmlReader = XmlReader.Create(fileStream, settings);

            if (!serializer.CanDeserialize(xmlReader))
            {
                throw new XmlException("This SVG file can not be deserialized. Please check the structure of the file.");
            }

            object deserializedModel = (serializer.Deserialize(xmlReader) ?? throw new XmlException("Failed to deserialize SVG file"));

            return Task.FromResult((Models.svg)deserializedModel);
        }
    }
}
