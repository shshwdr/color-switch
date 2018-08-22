using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PopupDialog : MonoBehaviour {
    public TextMeshProUGUI title;
    public TextMeshProUGUI message;
   
    public Button closeButton;

    public GameObject OneButtonPanel;
    public Button okButton;

    public GameObject TwoButtonPanel;
    public Button yesButton;
    public Button noButton;
    // Use this for initialization
    void Start () {
		
	}


    public void Setup(string t, string m, bool hasYesAndNo, DialogDelegate yesDelegate, DialogDelegate noDelegate)
    {
        title.text = t;
        message.text = m;
        closeButton.onClick.AddListener(delegate { if (noDelegate != null) { noDelegate(); } Destroy(gameObject); SFXController.Instance.ButtonClick(); });
        if (hasYesAndNo)
        {
            OneButtonPanel.SetActive(false);
            TwoButtonPanel.SetActive(true);
            yesButton.onClick.AddListener(delegate { if (yesDelegate != null) { yesDelegate(); } Destroy(gameObject); SFXController.Instance.ButtonClick(); });
            noButton.onClick.AddListener(delegate { if (noDelegate != null) { noDelegate(); } Destroy(gameObject); SFXController.Instance.ButtonClick(); });
        }
        else
        {
            OneButtonPanel.SetActive(true);
            TwoButtonPanel.SetActive(false);
            okButton.onClick.AddListener(delegate {
                Destroy(gameObject);
                SFXController.Instance.ButtonClick();
            });
        }
    }


	
	// Update is called once per frame
	void Update () {
		
	}
}
