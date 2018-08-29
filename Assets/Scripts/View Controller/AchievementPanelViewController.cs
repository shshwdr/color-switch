using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementPanelViewController : DefaultViewController
{
    public GameObject achievementCell;
    public GameObject achievementListPanel;
	// Use this for initialization
	void OnEnable () {
        InitAchievementView();

    }

    void InitAchievementView()
    {
        foreach(Transform child in achievementListPanel.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        foreach (Achievement achievement in AchievementManager.Instance.achievementList)
        {

            GameObject go = Instantiate(achievementCell, achievementListPanel.transform);
            AchievementCell script = go.GetComponent<AchievementCell>();
            script.InitCell(achievement);
        }
    }
}
