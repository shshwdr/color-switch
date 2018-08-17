using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PopupDialog : MonoBehaviour {
    public TextMeshProUGUI title;
    public TextMeshProUGUI message;
    public Button okButton;
    public Button closeButton;
	// Use this for initialization
	void Start () {
		
	}


    public void Setup(string t, string m)
    {
        title.text = t;
        message.text = m;
        okButton.onClick.AddListener(delegate {
            Destroy(gameObject);
        });
        closeButton.onClick.AddListener(delegate {
            Destroy(gameObject);
        });
    }


	
	// Update is called once per frame
	void Update () {
		
	}
}
