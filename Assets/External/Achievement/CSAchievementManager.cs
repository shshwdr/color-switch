using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sinbad;

enum AchievementState { locked, active, complete };


public class CSAchievementManager : Singleton<CSAchievementManager> {

    public List<AchievementInfo> achievementInfoList;
    
    public void Init()
    {
        ReadCSV();
        InitAchievements();
    }

    void Start()
    {

    }
    void ReadCSV()
    {
        achievementInfoList = CsvUtil.LoadObjects<AchievementInfo>("achievement.csv");
    }

    public void readCSV()
    {

    }
    void InitAchievements()
    {
        DataService ds = SQLiteDatabaseManager.Instance.ds;
        foreach (AchievementInfo achievementInfo in achievementInfoList)
        {
                CSAchievement achievement = new CSAchievement(achievementInfo);
            
        }
    }
}
