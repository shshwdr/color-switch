using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void AchievementCompleteDelegate();

public class CSAchievement{
    string identifier;
    public AchievementInfo achievementInfo;
    public PersistentAchievement persistentAchievement;

    List<CSAchievementStep> achievementSteps;
    List<AchievementCompleteDelegate> delegates;

    CSAchievement prerequisite;
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
        delegates = new List<AchievementCompleteDelegate>();
        LoadPrerequisite();
        LoadAchievementSteps();
        CheckForActivation();
        CheckToActivateAchievementStep();
        CheckForCompletion();
        LoadFallthrough();
        CheckForFallThroughtCompletion();
    }

    public void LoadPrerequisite()
    {
        string prerequisiteName = achievementInfo.prerequisite;
        if (prerequisiteName != null && prerequisiteName.Length != 0)
        {
            if (CSAchievementManager.Instance.achievementDictionary.ContainsKey(prerequisiteName))
            {
                prerequisite = CSAchievementManager.Instance.achievementDictionary[prerequisiteName];
                prerequisite.RegisterCompletionDelegate(delegate { CompleteMethod(); });
            }
            else
            {
                Debug.LogError("prerequisite does not exist: " + prerequisiteName);
            }
        }
    }

    void LoadAchievementSteps()
    {
        //only support one step now

    }

    void LoadFallthrough()
    {

    }

    void RegisterCompletionDelegate(AchievementCompleteDelegate dele)
    {
        delegates.Add(dele);
    }

    

    void CheckToChangeState()
    {
        CheckForActivation();
        CheckForCompletion();
        CheckForFallThroughtCompletion();
    }

    void CheckForActivation()
    {
        if (persistentAchievement.state != (int)AchievementState.locked)
        {
            return;
        }
        bool shouldActivate = true;
        if (prerequisite !=null && !prerequisite.IsComplete())
        {
            shouldActivate = false;
        }
        if (shouldActivate)
        {
            SetState(AchievementState.active);
            CheckToActivateAchievementStep();
        }
    }

    void CheckToActivateAchievementStep()
    {
        if(persistentAchievement.state == (int)AchievementState.active)
        {

        }
    }

    void CheckForCompletion()
    {

    }

    void CheckForFallThroughtCompletion()
    {

    }

    public bool IsComplete()
    {
        return persistentAchievement.state == (int)AchievementState.complete;
    }

    void CompleteMethod()
    {
        CheckToChangeState();
    }
    

    public void SetState(AchievementState s)
    {
        DataService ds = SQLiteDatabaseManager.Instance.ds;
        persistentAchievement.state = (int)s;
        ds.UpdateAchievement(persistentAchievement);
        CheckToChangeState();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
