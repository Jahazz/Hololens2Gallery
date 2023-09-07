using System.IO;
using System.Xml.Serialization;

namespace Codebase.IO.Xml
{
    public static class XMLUtils
    {
        public static void SerializeAndSave<ObjectType> (ObjectType objectToSerialize, string path, string filename)
        {
            using (FileStream file = new FileStream(Path.Combine(path, filename), FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObjectType));

                serializer.Serialize(file, objectToSerialize);
            }
        }

        public static ObjectType LoadAndDeserialize<ObjectType> (string path, string filename)
        {
            ObjectType output;

            using (FileStream file = new FileStream(Path.Combine(path, filename), FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObjectType));

                output = (ObjectType)serializer.Deserialize(file);
            }

            return output;
        }
    }
}

