using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sinbad;

public enum AchievementState { locked, active, complete };


public class AchievementManager : Singleton<AchievementManager> {

    public Dictionary<string,Achievement> achievementDictionary;
    public Dictionary<string, AchievementStep> achievementStepDictionary;
    public Dictionary<string, AchievementStepInfo> achievementStepInfoDictionary;

    public Dictionary<string, Achievement>.ValueCollection achievementList { get { return achievementDictionary.Values; } }

    public void Init()
    {
        InitAchievementStep();
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
        achievementStepDictionary = new Dictionary<string, AchievementStep>();
        List<AchievementInfo> achievementInfoList = CsvUtil.LoadObjects<AchievementInfo>("achievement.csv");
        foreach (AchievementInfo achievementInfo in achievementInfoList)
        {
                Achievement achievement = new Achievement(achievementInfo);
            achievementDictionary[achievementInfo.identifier] = achievement;
        }
    }

    void InitAchievementStep()
    {
        achievementStepInfoDictionary = new Dictionary<string, AchievementStepInfo>();
        List<AchievementStepInfo> achievementStepInfoList = CsvUtil.LoadObjects<AchievementStepInfo>("achievementStep.csv");
        foreach(AchievementStepInfo info in achievementStepInfoList)
        {
            achievementStepInfoDictionary[info.identifier] = info;
        }
    }

    public AchievementStep GetAchievementStep(string identifier)
    {
        AchievementStep achievementStep = null;
        if(achievementStepDictionary.ContainsKey(identifier))
        {
            achievementStep = achievementStepDictionary[identifier];
        } else
        {
            AchievementStepInfo info = achievementStepInfoDictionary[identifier];
            if (info == null)
            {
                Debug.LogError(identifier + " does not exist in achievement steps");
            }
            achievementStep = AchievementStepFactory.CreateAchievementStep(info);
            achievementStepDictionary[identifier] = achievementStep;
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
