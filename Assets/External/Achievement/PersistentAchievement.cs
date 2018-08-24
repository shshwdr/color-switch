using SQLite4Unity3d;

public class PersistentAchievement {
    [PrimaryKey]
    public string identifier { get; set; }
    public int state { get; set; }
    public override string ToString()
    {
        return string.Format("[Currency: identifier = {0}, amount = {1}", identifier, state);
    }
}
