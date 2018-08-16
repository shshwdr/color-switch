using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityCell : MonoBehaviour {
    public Image icon;
    public TextMeshProUGUI abilityName;
    public TextMeshProUGUI description;
    public TextMeshProUGUI abilityText;
    public GameObject unlockPanel;
    public GameObject usePanel;
    public TextMeshProUGUI price;
    // Use this for initialization
    void Start () {
		
	}
	

    public void SetupCell(AbilityInfo info)
    {
        abilityName.text = info.name;
        abilityText.text = info.ability;
        description.text = info.description;
        //icon.sprite = info.icon;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
