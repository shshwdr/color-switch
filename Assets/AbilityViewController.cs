using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityViewController : MonoBehaviour {
    public GameObject abilityCellPrefab;
    public GameObject abilityPanel;
	// Use this for initialization
	void Start () {
        List<AbilityInfo> infoList =  AbilityManager.Instance.abilityInfoList;
        foreach(AbilityInfo info in infoList)
        {
            GameObject go = Instantiate(abilityCellPrefab, abilityPanel.transform);
            AbilityCell script = go.GetComponent<AbilityCell>();
            script.SetupCell(info);

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
