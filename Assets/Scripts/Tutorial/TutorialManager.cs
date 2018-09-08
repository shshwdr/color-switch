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
        ReadCSV();
        ShowTutorial(0,"a","b");
    }

    // Update is called once per frame
    void Update () {
		
	}
    void ReadCSV()
    {
       // tutorialNarrationInfoList = CsvUtil.LoadObjects<TutorialNarrationInfo>("tutorialNarration.csv");
    }

    public void ShowTutorial(Dictionary<string,string> dict)
    {

    }

    public void ShowTutorial(int index,string title, string message)
    {
        GameLogicManager.Instance.isPaused = true;
        DialogDelegate okDialog = delegate { Destroy(currentTutorial); currentTutorial = null; GameLogicManager.Instance.isPaused = false; };
        PopupDialogManager.Instance.CreatePopupDialog(title, message, okDialog, TextAlignmentOptions.Bottom, true);
        currentTutorial = Instantiate(tutorialAnimPrefabs[index], transform);
    }
}
