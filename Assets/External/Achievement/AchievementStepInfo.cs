using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementStepInfo{
    public string identifier;
    public string requirementClassString;
    public int requirementAmount;
    public string category;
    public override string ToString()
    {
        return "AchievementStepInfo: "+identifier;
    }
}
