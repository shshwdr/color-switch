using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AchievementAmountStep : AchievementStep {
    PersistentAchievementAmountStep persistentAchievementAmountStep;
    public override AchievementState state { get { return (AchievementState)persistentAchievementAmountStep.state; }
    set { AchievementState oldState = (AchievementState)persistentAchievementAmountStep.state;
            persistentAchievementAmountStep.state = (int)value;
            DataService ds = SQLiteDatabaseManager.Instance.ds;
            ds.UpdateAchievementAmountStep(persistentAchievementAmountStep);
            if (achievementStepDelegate != null)
            {
                achievementStepDelegate(this, oldState, value);
            }
            else
            {
                Debug.LogError("achievementStepDelegate does not have value" + identifier);
            }
        } }
    public AchievementAmountStep(AchievementStepInfo info)
    {
        stepInfo = info;
        identifier = info.identifier;
        DataService ds = SQLiteDatabaseManager.Instance.ds;
        persistentAchievementAmountStep = ds.GetPersistentAchievementAmountStep(identifier);
        if (persistentAchievementAmountStep == null)
        {
            persistentAchievementAmountStep = new PersistentAchievementAmountStep();
            persistentAchievementAmountStep.identifier = identifier;
            persistentAchievementAmountStep.state = (int)AchievementState.locked;
            persistentAchievementAmountStep.currentAmount = 0;
            ds.InsertAchievementAmountStep(persistentAchievementAmountStep);
        }
        LockIfNotComplete();
    }

    public override string ToString()
    {
        return identifier + " " + state;
    }

}
