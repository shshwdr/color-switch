using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void AchievementCompleteDelegate();

public class CSAchievement{
    string identifier;
    public AchievementInfo achievementInfo;
    public PersistentAchievement persistentAchievement;

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
        SetupPrerequisite();
        //load steps
        CheckForActivation();
        CheckToActivateAchievementStep();
        CheckForCompletion();
        //load fallthrough
        CheckForFallThroughtCompletion();
    }

    void registerCompletionDelegate(AchievementCompleteDelegate dele)
    {
        delegates.Add(dele);
    }

    public void SetupPrerequisite()
    {
        string prerequisiteName = achievementInfo.prerequisite;
        if (prerequisiteName != null&&prerequisiteName.Length !=0)
        {
            if (CSAchievementManager.Instance.achievementDictionary.ContainsKey(prerequisiteName)) { 
                prerequisite = CSAchievementManager.Instance.achievementDictionary[prerequisiteName];
                prerequisite.registerCompletionDelegate(delegate { CompleteMethod(); });
            }
            else
            {
                Debug.LogError("prerequisite does not exist: " + prerequisiteName);
            }
        }
    }

    void CHeckToChangeState()
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
        CHeckToChangeState();
    }
    

    public void SetState(AchievementState s)
    {
        DataService ds = SQLiteDatabaseManager.Instance.ds;
        persistentAchievement.state = (int)s;
        ds.UpdateAchievement(persistentAchievement);
        CHeckToChangeState();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
