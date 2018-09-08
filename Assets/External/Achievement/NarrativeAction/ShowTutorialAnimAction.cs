using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTutorialAnimAction : NarrativeAction {
   public ShowTutorialAnimAction(NarrativeInfo info) : base(info)
    {

    }

    protected override void P_Enable()
    {
        Debug.Log("enable tutorial action with info: " + narrativeInfo);
        TutorialManager.Instance.ShowTutorial(narrativeInfo.param);
    }
}
