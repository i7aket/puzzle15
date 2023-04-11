namespace puzzle15;

public interface ISaveLoad <T>
{ 
    public void Save(T obj);
    public T Load();
}