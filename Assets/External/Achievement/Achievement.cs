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
        set
        {
            AchievementState oldState = (AchievementState)persistentAchievement.state;
            persistentAchievement.state = (int)value;
            DataService ds = SQLiteDatabaseManager.Instance.ds;
            ds.UpdateAchievement(persistentAchievement);
            CheckToChangeState();
            //Debug.LogError("oldstate " + oldState + " new state " + persistentAchievement.state);
            if (oldState != AchievementState.complete && value == AchievementState.complete)
            {
                //Debug.LogError("deles " + delegates);
                foreach (AchievementCompleteDelegate dele in delegates)
                {
                    dele();
                }
            }
            NarrativeManager.Instance.UpdateAchievement(identifier, oldState, value);
        }
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
            state = AchievementState.locked;
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
                prerequisite.RegisterCompletionDelegate(delegate { Debug.Log("delegate triggers"); CompleteMethod(); });
            }
            else
            {
                Debug.LogError("prerequisite does not exist: " + prerequisiteName);
            }
        }
    }

    void LoadAchievementSteps()
    {
        Debug.Log("LoadAchievementSteps");
        //only support one step now
        if (achievementInfo.achievementStep == null || achievementInfo.achievementStep.Length == 0)
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
        Debug.Log("ChangeStateForAchievementStep " + identifier);
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
        //Debug.LogError("register " + identifier);
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
        //Debug.LogError("prerequisite " + prerequisite + (prerequisite==null ? "none" : prerequisite.state.ToString()));
        if (state != AchievementState.locked)
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
            state = AchievementState.active;
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
        if(state != AchievementState.active)
        {
            return;
        }
        if (achievementStep == null)
        {
            LoadAchievementSteps();
        }
        if (achievementStep.IsComplete())
        {
            state = AchievementState.complete;
        }
    }

    void CheckForFallThroughtCompletion()
    {

    }

    public bool IsComplete()
    {
        return state == AchievementState.complete;
    }

    void CompleteMethod()
    {
        CheckToChangeState();
    }

    public void CleanStep()
    {
        achievementStep.state = AchievementState.locked;
    }

    public void FinishStep()
    {
        achievementStep.state = AchievementState.complete;
    }

    public override string ToString()
    {
        return identifier + " " + state+" steps: "+achievementStep.ToString();
    }
}
