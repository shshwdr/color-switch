using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityViewController : MonoBehaviour {
    public GameObject abilityCellPrefab;
    public GameObject abilityPanel;

    public Dictionary<string,AbilityCell> cellDictionary;
	// Use this for initialization
	void Start () {
        List<AbilityInfo> infoList =  AbilityManager.Instance.abilityInfoList;
        cellDictionary = new Dictionary<string, AbilityCell>();
        foreach(AbilityInfo info in infoList)
        {
            GameObject go = Instantiate(abilityCellPrefab, abilityPanel.transform);
            AbilityCell script = go.GetComponent<AbilityCell>();
            script.SetupCell(info);
            cellDictionary[info.identifier] = script;
            script.viewController = this;
        }
	}
    public void UpdateCellWithIdentifier(string identifier)
    {
        cellDictionary[identifier].SetupState(identifier);
    }

	
	// Update is called once per frame
	void Update () {
		
	}

}
