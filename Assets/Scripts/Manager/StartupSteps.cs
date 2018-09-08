using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartupSteps : MonoBehaviour {

    private void Awake()
    {
        SQLiteDatabaseManager.Instance.Init();
        CheatManager.Instance.Init();
        CurrencyManager.Instance.Init();
        AbilityManager.Instance.Init();
        AchievementManager.Instance.Init();
        NarrativeManager.Instance.Init();
        TutorialManager.Instance.Init();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
