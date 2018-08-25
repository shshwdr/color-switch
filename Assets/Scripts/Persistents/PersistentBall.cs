using SQLite4Unity3d;

public class PersistentBall {
    [PrimaryKey]
    public string identifier { get; set; }
    public bool isUsing { get; set; }
    
    public override string ToString()
    {
        return string.Format("[Currency: identifier = {0}, amount = {1}", identifier, isUsing);
    }
}
