using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public delegate void CheatActionDelegate();
public class CheatCell : MonoBehaviour {
    public Image icon;
    public TextMeshProUGUI description;
    public Button cheatButton;
	// Use this for initialization
	void Start () {
		
	}

    public void InitCell(string desc, CheatActionDelegate actionDelegate)
    {
        description.text = desc;
        cheatButton.onClick.AddListener(delegate
        {
            actionDelegate();
        });
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
