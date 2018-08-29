using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void AchievementCompleteDelegate();

public class Achievement{
    string identifier;
    public AchievementInfo achievementInfo;
    public PersistentAchievement persistentAchievement;

    AchievementStep achievementStep;
    List<AchievementCompleteDelegate> delegates;

    public AchievementState state
    {
        get { return (AchievementState)persistentAchievement.state; }
    }

        Achievement prerequisite;
    public Achievement(AchievementInfo info)
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
            if (AchievementManager.Instance.achievementDictionary.ContainsKey(prerequisiteName))
            {
                prerequisite = AchievementManager.Instance.achievementDictionary[prerequisiteName];
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
        if(achievementInfo.achievementStep == null || achievementInfo.achievementStep.Length == 0)
        {
            Debug.LogError("achievement does not have step: " + identifier);
        }
        achievementStep = AchievementManager.Instance.GetAchievementStep(achievementInfo.achievementStep);
        if (achievementStep != null)
        {
            achievementStep.AddAchievementDelegate(ChangeStateForAchievementStep);
        }else
        {
            Debug.LogError("achievement step didn't find: " + achievementStep.ToString());
        }
    }

    void ChangeStateForAchievementStep(AchievementStep step,AchievementState oldState, AchievementState newState)
    {
        if (step.IsComplete())
        {

        }
        CheckToChangeState();
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
        if(state == AchievementState.active)
        {
            achievementStep.Activate();
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

    public override string ToString()
    {
        return identifier + " " + state+" steps: "+achievementStep.ToString();
    }
}
