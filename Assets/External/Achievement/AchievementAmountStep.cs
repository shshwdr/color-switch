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
        } }
    public AchievementAmountStep(AchievementStepInfo info)
    {
        stepInfo = info;
        identifier = info.identifier;
        DataService ds = SQLiteDatabaseManager.Instance.ds;
        persistentAchievementAmountStep = ds.GetPersistentAchievementAmountStep(identifier);
        Debug.Log("start achievement " + info);
        if (persistentAchievementAmountStep == null)
        {
            Debug.Log("init new persistent achievement " + info);
            persistentAchievementAmountStep = new PersistentAchievementAmountStep();
            persistentAchievementAmountStep.identifier = identifier;
            persistentAchievementAmountStep.state = (int)AchievementState.locked;
            persistentAchievementAmountStep.currentAmount = 0;
            ds.InsertAchievementAmountStep(persistentAchievementAmountStep);
        }
        LockIfNotComplete();
    }

    protected override Requirement RequirementFromAchievementStepInfo(AchievementStepInfo achievementStepInfo)
    {
        System.Type requirementType = System.Type.GetType(achievementStepInfo.requirementClassString);

        return (Requirement)System.Activator.CreateInstance(requirementType, achievementStepInfo, persistentAchievementAmountStep.currentAmount);
    }

    public override void Activate()
    {
        base.Activate();
        //we only have 1 amount now
        //((AmountRequirement)requirement).ProgressChangedCallback+=
    }

    public override string ToString()
    {
        return identifier + " " + state;
    }

}
