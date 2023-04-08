namespace puzzle15;

public interface ISaveLoad <T>
{ 
    public void Save(T obj, string filePath);
    public T Load(string filePath);
}