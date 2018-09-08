using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementInfo {

    public string identifier;
    public string prerequisite;
    public string achievementStep;
    public string fallThrough;
    public string description;
    public bool isTutorial;
    public string reward;
    public string comment;

    public override string ToString()
    {
        return "AchievementInfo: "+identifier;
    }
}
