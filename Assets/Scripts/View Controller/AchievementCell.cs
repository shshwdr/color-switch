using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementCell : MonoBehaviour {
    public Image icon;
    public TextMeshProUGUI description;
    public Button cheatButton;
	// Use this for initialization
	void Start () {
		
	}

    public void InitCell(Achievement achievement)
    {
        description.text = achievement.achievementInfo.description+" "+ achievement.ToString();
        cheatButton.onClick.AddListener(delegate {
        });
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
