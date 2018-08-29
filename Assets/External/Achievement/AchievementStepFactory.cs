using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementStepFactory {

	public static AchievementStep CreateAchievementStep(AchievementStepInfo info)
    {
        //use reflection later
        if (info.requirementClassString == "PlayerReachedLocationRequirement")
        {
            AchievementAmountStep step = new AchievementAmountStep(info);
            return step;
        }
        return null;
    }
}
