using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSAchievement{
    string identifier;
    public AchievementInfo achievementInfo;
    PersistentAchievement persistentAchievement;
    public CSAchievement(AchievementInfo info)
    {
        achievementInfo = info;
        identifier = info.identifier;

        DataService ds = SQLiteDatabaseManager.Instance.ds;
        persistentAchievement = ds.GetPersistentAchievement(identifier);
        if (persistentAchievement == null)
        {
            persistentAchievement = new PersistentAchievement();
            persistentAchievement.identifier = identifier;
            persistentAchievement.state = (int)AchievementState.locked;
            ds.InsertAchievement(persistentAchievement);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
