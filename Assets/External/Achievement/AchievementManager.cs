using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sinbad;

public enum AchievementState { locked, active, complete };


public class CSAchievementManager : Singleton<CSAchievementManager> {

    public Dictionary<string,Achievement> achievementDictionary;
    public Dictionary<string, AchievementStep> achievementStepDictionary;
    public Dictionary<string, AchievementStepInfo> achievementStepInfoDictionary;

    public Dictionary<string, Achievement>.ValueCollection achievementList { get { return achievementDictionary.Values; } }

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

        achievementDictionary = new Dictionary<string, Achievement>();
    List<AchievementInfo> achievementInfoList = CsvUtil.LoadObjects<AchievementInfo>("achievement.csv");
    DataService ds = SQLiteDatabaseManager.Instance.ds;
        foreach (AchievementInfo achievementInfo in achievementInfoList)
        {
                Achievement achievement = new Achievement(achievementInfo);
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

    AchievementStep GetAchievementStep(string identifier)
    {
        AchievementStep achievementStep = achievementStepDictionary[identifier];
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
        foreach(Achievement achievement in achievementList)
        {
            achievement.SetState(AchievementState.complete);
        }
    }

    public void CleanAchievements()
    {
        foreach (Achievement achievement in achievementList)
        {
            achievement.SetState(AchievementState.locked);
        }
    }
}
