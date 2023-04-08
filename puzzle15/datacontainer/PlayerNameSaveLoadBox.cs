namespace puzzle15;

public class PlayerNameSaveLoadBox
{

    public string Name{ get; private set; }
    
    
    public PlayerNameSaveLoadBox(string name)
    {
        Name = name;
    }
}