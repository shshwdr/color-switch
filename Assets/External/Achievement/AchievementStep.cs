using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void AchievementStepDelegate(AchievementStep step, AchievementState oldState, AchievementState newState);

public class AchievementStep {

    protected AchievementStepInfo stepInfo;
    protected string identifier;

    protected AchievementStepDelegate achievementStepDelegate;

    public virtual AchievementState state { get { return AchievementState.locked; }
        set {  }
    }

    public void AddAchievementDelegate(AchievementStepDelegate dele)
    {
        achievementStepDelegate = dele;
    }



    public virtual void Activate()
    {
        if(state == AchievementState.locked)
        {
            state = AchievementState.active;
        }
    }

    public virtual bool IsComplete()
    {
        return state == AchievementState.complete;
    }

    protected void LockIfNotComplete()
    {
        if (!IsComplete())
        {
            state = AchievementState.locked;
        }
    }

}
