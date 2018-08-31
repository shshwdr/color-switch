using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReachedLocationRequirement : AmountRequirement
{
    float targetYPosition;

    public PlayerReachedLocationRequirement(AchievementStepInfo stepInfo, int initial):base(stepInfo,initial)
    {
        targetYPosition = float.Parse(stepInfo.category);
        if(GameLogicManager.Instance.player) {
            GameLogicManager.Instance.player.OnPositionChange += UpdatePlayerPosition;
        }
    }

    void UpdatePlayerPosition(Vector3 pos)
    {
        if(pos.y >= targetYPosition)
        {
            UpdateProgressByAmount(1);
            if (GameLogicManager.Instance.player)
            {
                Debug.Log("finish requirement "+ "PlayerReachedLocationRequirement");
                GameLogicManager.Instance.player.OnPositionChange -= UpdatePlayerPosition;
            }
        }
    }


}
