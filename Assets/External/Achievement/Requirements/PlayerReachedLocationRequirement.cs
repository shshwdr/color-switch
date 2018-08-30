using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReachedLocationRequirement : AmountRequirement
{
    float targetYPosition;

    public PlayerReachedLocationRequirement(AchievementStepInfo stepInfo, int initial):base(stepInfo,initial)
    {
        Debug.Log("init PlayerReachedLocationRequirement");
        targetYPosition = float.Parse(stepInfo.category);
        GameLogicManager.Instance.player.OnPositionChange += UpdatePlayerPosition;
    }

    void UpdatePlayerPosition(Vector3 pos)
    {
        Debug.Log("update position " + pos);
    }


}
