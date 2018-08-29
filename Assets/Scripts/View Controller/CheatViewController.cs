using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatViewController : DefaultViewController
{
    public GameObject cheatCell;
    public Transform cheatListTransform;
	// Use this for initialization
	void Start () {
        InitCheatView();

    }
    void InitCheatView()
    {
        CreateCheatButton("clean achievements", delegate
        {
            AchievementManager.Instance.CleanAchievements();
        });
        CreateCheatButton("finish achievements", delegate
        {
            AchievementManager.Instance.FinishAchievements();
        });
    }

    void CreateCheatButton(string title,CheatActionDelegate dele)
    {
        GameObject go = Instantiate(cheatCell, cheatListTransform);
        CheatCell  script = go.GetComponent<CheatCell>();
        script.InitCell(title,dele);
    }
}
