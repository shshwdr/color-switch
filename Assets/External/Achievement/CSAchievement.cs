using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSAchievement{
    string identifier;
    AchievementInfo achievementInfo;
    PersistentAchievement persistentAchievement;
    public CSAchievement(AchievementInfo info)
    {
        achievementInfo = info;
        identifier = info.identifier;

        DataService ds = SQLiteDatabaseManager.Instance.ds;
        persistentAchievement = ds.GetPersistentAchievement(identifier);
        if (persistentAchievement == null)
        {
            PersistentAchievement newAchievement = new PersistentAchievement();
            newAchievement.identifier = identifier;
            newAchievement.state = (int)AchievementState.locked;
            ds.InsertAchievement(newAchievement);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
