using System.Xml.Serialization;

namespace Puzzle15;

public class XmlSave<T> : ISave<T>, ILoad<T> 
{
    private string _filePath;
    
    public XmlSave (string filePath = "noname.xml")
    {
        _filePath = filePath;
    }
    
    public void Save(T obj)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        using (FileStream fileStream = new FileStream(_filePath, FileMode.OpenOrCreate))
        {
            xmlSerializer.Serialize(fileStream, obj);
        }
    }

    public T Load()
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        using (FileStream fileStream = new FileStream(_filePath, FileMode.Open))
        {
            return (T)xmlSerializer.Deserialize(fileStream);
        }
    }
}