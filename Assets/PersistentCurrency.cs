using SQLite4Unity3d;

public class PersistentCurrency {
    [PrimaryKey]
    public string identifier { get; set; }
    public int amount { get; set; }
    public override string ToString()
    {
        return string.Format("[Currency: identifier = {0}, amount = {1}", identifier, amount);
    }
}
