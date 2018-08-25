using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sinbad;

public enum AchievementState { locked, active, complete };


public class CSAchievementManager : Singleton<CSAchievementManager> {

    public List<CSAchievement> achievementList;

    public void Init()
    {
        InitAchievements();
    }

    void Start()
    {

    }


    public void readCSV()
    {

    }
    void InitAchievements()
    {

        achievementList = new List<CSAchievement>();
    List<AchievementInfo> achievementInfoList = CsvUtil.LoadObjects<AchievementInfo>("achievement.csv");
    DataService ds = SQLiteDatabaseManager.Instance.ds;
        foreach (AchievementInfo achievementInfo in achievementInfoList)
        {
                CSAchievement achievement = new CSAchievement(achievementInfo);
            achievementList.Add(achievement);
        }
    }

    public void FinishAchievements()
    {
        foreach(CSAchievement achievement in achievementList)
        {
            achievement.SetState(AchievementState.complete);
        }
    }

    public void CleanAchievements()
    {
        foreach (CSAchievement achievement in achievementList)
        {
            achievement.SetState(AchievementState.locked);
        }
    }
}
