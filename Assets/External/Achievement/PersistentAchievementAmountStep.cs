using SQLite4Unity3d;


public class PersistentAchievementAmountStep {

    [PrimaryKey]
    public string identifier { get; set; }
    public int state { get; set; }
    public int currentAmount { get; set; }

    public override string ToString()
    {
        return string.Format("[Currency: identifier = {0}, amount = {1}", identifier, state);
    }
}
