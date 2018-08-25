using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementPanelViewController : DefaultViewController
{
    public GameObject achievementCell;
    public Transform achievementListTransform;
	// Use this for initialization
	void Start () {
        InitAchievementView();

    }
    void InitAchievementView()
    {
        foreach (CSAchievement achievement in CSAchievementManager.Instance.achievementList)
        {

            GameObject go = Instantiate(achievementCell,achievementListTransform);
            AchievementCell script = go.GetComponent<AchievementCell>();
            script.InitCell(achievement);
        }
    }
}
