using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sinbad;

public enum AchievementState { locked, active, complete };


public class CSAchievementManager : Singleton<CSAchievementManager> {

    public Dictionary<string,CSAchievement> achievementDictionary;
    public Dictionary<string, CSAchievementStep> achievementStepDictionary;
    public Dictionary<string, AchievementStepInfo> achievementStepInfoDictionary;

    public Dictionary<string, CSAchievement>.ValueCollection achievementList { get { return achievementDictionary.Values; } }

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

        achievementDictionary = new Dictionary<string, CSAchievement>();
    List<AchievementInfo> achievementInfoList = CsvUtil.LoadObjects<AchievementInfo>("achievement.csv");
    DataService ds = SQLiteDatabaseManager.Instance.ds;
        foreach (AchievementInfo achievementInfo in achievementInfoList)
        {
                CSAchievement achievement = new CSAchievement(achievementInfo);
            achievementDictionary[achievementInfo.identifier] = achievement;
        }
    }

    void InitAchievementStep()
    {
        List<AchievementStepInfo> achievementStepInfoList = CsvUtil.LoadObjects<AchievementStepInfo>("achievementStep.csv");
        foreach(AchievementStepInfo info in achievementStepInfoList)
        {
            achievementStepInfoDictionary[info.identifier] = info;
        }
    }

    CSAchievementStep GetAchievementStep(string identifier)
    {
        CSAchievementStep achievementStep = achievementStepDictionary[identifier];
        if(achievementStep == null)
        {
            AchievementStepInfo info = achievementStepInfoDictionary[identifier];
            if(info == null)
            {
                Debug.LogError(identifier + " does not exist in achievement steps");
            }
            //create achievement step info
        }
        return achievementStep;
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
