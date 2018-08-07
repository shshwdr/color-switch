using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GamePanelViewController : MonoBehaviour {
    TextMeshProUGUI heartAmountText;
    TextMeshProUGUI goldAmountText;
    TextMeshProUGUI levelAmountText;
    // Use this for initialization
    void Start () {
        heartAmountText = GameObject.Find("heartAmount").GetComponent<TextMeshProUGUI>();
        goldAmountText = GameObject.Find("goldAmount").GetComponent<TextMeshProUGUI>();
        levelAmountText = GameObject.Find("levelAmount").GetComponent<TextMeshProUGUI>();
    }
	
	// Update is called once per frame
	void Update () {
        //temp!
        goldAmountText.text = CurrencyManager.Instance.GetCurrencyAount(CSConstant.GOLD).ToString();
	}
}
