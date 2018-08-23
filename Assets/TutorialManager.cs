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
        ReadCSV();
        ShowTutorial(0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void ReadCSV()
    {
        tutorialNarrationInfoList = CsvUtil.LoadObjects<TutorialNarrationInfo>("tutorialNarration.csv");
    }

    public void ShowTutorial(int index)
    {
        GameLogicManager.Instance.isPaused = true;
        DialogDelegate okDialog = delegate { Destroy(currentTutorial); currentTutorial = null; GameLogicManager.Instance.isPaused = false; };
        PopupDialogManager.Instance.CreatePopupDialog(tutorialNarrationInfoList[index].title, tutorialNarrationInfoList[index].message, okDialog, TextAlignmentOptions.Bottom, true);
        currentTutorial = Instantiate(tutorialAnimPrefabs[index], transform);
    }
}
