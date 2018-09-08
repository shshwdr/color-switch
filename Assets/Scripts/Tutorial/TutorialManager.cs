using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sinbad;
using TMPro;
using UnityEngine.UI;

public class TutorialManager : Singleton<TutorialManager> {
    public List<TutorialNarrationInfo> tutorialNarrationInfoList;
    public GameObject[] tutorialAnimPrefabs;
    GameObject currentTutorial;
    // Use this for initialization
    void Start () {
        
    }

    public void Init()
    {
        //ShowTutorial(0,"a","b");
    }

    // Update is called once per frame
    void Update () {
		
	}

    static readonly string INDEX = "index";
    static readonly string TITLE = "title";
    static readonly string MESSAGE = "message";

    public void ShowTutorial(Dictionary<string,string> dict)
    {
        if (dict.ContainsKey(INDEX) && dict.ContainsKey(TITLE) && dict.ContainsKey(MESSAGE))
        {
            ShowTutorial(int.Parse(dict[INDEX]), dict[TITLE], dict[MESSAGE]);
        }else
        {
            Debug.LogError("some keys are missing in tutorial params: " + dict);
        }
    }

    public void ShowTutorial(int index,string title, string message)
    {
        GameLogicManager.Instance.isPaused = true;
        DialogDelegate okDialog = delegate { Destroy(currentTutorial); currentTutorial = null; GameLogicManager.Instance.isPaused = false; };
        PopupDialogManager.Instance.CreatePopupDialog(title, message, okDialog, TextAlignmentOptions.Bottom, true);
        currentTutorial = Instantiate(tutorialAnimPrefabs[index], transform);
    }
}
