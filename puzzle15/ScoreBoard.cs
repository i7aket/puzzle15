namespace Puzzle15;

public class ScoreBoard
{
    private List<Player>? _list;

    private readonly JsonSaveLoad<List<Player>?> _saveLoadLoadProvider = new JsonSaveLoad<List<Player>?>( "save.json");
    //public XmlSave<List<Player>?> SaveLoadProvider = new XmlSave<List<Player>?>( "save.xml");
    
    public ScoreBoard ()
    {
        if (_saveLoadLoadProvider.Load() != null)
        {
            _list = _saveLoadLoadProvider.Load();
        }
        else
        {
            _list = new List<Player>();
        }
    }

    public void SaveList()
    {
        _saveLoadLoadProvider.Save(_list);
    }

    public int CountPlayers()
    {
        if (_list != null) return _list.Count;
        else return 0;
    }

    public string PlayerName(int n)
    {
        return _list[n].Name;
    }
    
    public string PlayerTime(int n)
    {
        return _list[n].Ts.ToString(@"mm\:ss");
    }
    
    public string PlayerMoves(int n)
    {
        return _list[n].Moves.ToString();
    }
    
    public void AddPlayer(Player player)
    {
        _list.Add(player);
    }
    
    
    public void Sort()
    {
        if (_list.Count > 0)
        {
            for (int indexLower = 0; indexLower < _list.Count; indexLower++) {

                for (int i = indexLower + 1; i < _list.Count; i++)
                {
                    int result = TimeSpan.Compare(_list[indexLower].Ts, _list[i].Ts);
                    if (result > 0)
                    {
                        (_list[i], _list[indexLower]) = (_list[indexLower], _list[i]);
                    }
                }
            }
        }
    }
}