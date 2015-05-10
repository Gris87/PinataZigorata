#define LEVEL_INFO_DEBUG

using UnityEngine;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

[XmlRoot("level")]
public class LevelInfo
{
    public string name;
    public string background;
    public int    rows;
    public int    columns;

    public void save(string path)
    {
#if LEVEL_INFO_DEBUG
        Debug.Log("Save level info to " + path);
#endif

        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
        ns.Add("","");

        XmlSerializer serializer = new XmlSerializer(typeof(LevelInfo));

        StreamWriter stream = new StreamWriter(path, false, Encoding.UTF8);
        serializer.Serialize(stream, this, ns);
        stream.Close();
    }

    public static LevelInfo load(string path)
    {
#if LEVEL_INFO_DEBUG
        Debug.Log("Load level info from " + path);
#endif

        XmlSerializer serializer = new XmlSerializer(typeof(LevelInfo));

        StreamReader stream = new StreamReader(path, Encoding.UTF8, true);
        LevelInfo res = serializer.Deserialize(stream) as LevelInfo;
        stream.Close();

        return res;
    }

    public static LevelInfo loadFromText(string text)
    {
#if LEVEL_INFO_DEBUG
        Debug.Log("Load level info from text");
#endif

        XmlSerializer serializer = new XmlSerializer(typeof(LevelInfo));
        return serializer.Deserialize(new StringReader(text)) as LevelInfo;
    }
}
