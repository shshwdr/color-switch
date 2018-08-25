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
            CSAchievementManager.Instance.CleanAchievements();
        });
        CreateCheatButton("finish achievements", delegate
        {
            CSAchievementManager.Instance.FinishAchievements();
        });
    }

    void CreateCheatButton(string title,CheatActionDelegate dele)
    {
        GameObject go = Instantiate(cheatCell, cheatListTransform);
        CheatCell  script = go.GetComponent<CheatCell>();
        script.InitCell(title,dele);
    }
}
