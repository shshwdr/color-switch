using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Completable
{
    bool IsCompleted { get; }
}

public class AmountRequirement : Requirement {
    public override bool IsCompleted { get {return currentAmount>=requiredAmount; } }

    protected int requiredAmount;
    protected int initialAmount;
    protected int currentAmount;

    public delegate void OnProgressChangedCallback(int newVal);
    public event OnProgressChangedCallback ProgressChangedCallback;

    public AmountRequirement(AchievementStepInfo stepInfo,int initial)
    {
        requiredAmount = stepInfo.requirementAmount;
        initialAmount = initial;
    }

    public void UpdateProgressByAmount(int amount)
    {
        currentAmount = amount;
        if (ProgressChangedCallback != null)
        {
            ProgressChangedCallback(amount);
        }
    }

    
}
