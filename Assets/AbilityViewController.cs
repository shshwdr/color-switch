using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AbilityViewController : DefaultViewController
{
    public GameObject abilityCellPrefab;
    public GameObject abilityPanel;
    public TextMeshProUGUI currentGoldText;

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
        UpdateView();
	}

    public void UpdateView()
    {
        currentGoldText.text = CurrencyManager.Instance.GetCurrencyAount("gold").ToString();
        UpdateCells();
    }

    void UpdateCells()
    {
        foreach(AbilityCell cell in cellDictionary.Values)
        {
            cell.UpdateState();
        }
    }
    

}
