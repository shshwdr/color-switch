﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
//help and setting

public class SharedViewController : MonoBehaviour {
    public GameObject itemHelpCell;
    public GameObject itemHelpPanel;
    // Use this for initialization
    void Start()
    {
        InitHelpView();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void InitHelpView()
    {
        foreach (ItemInfo info in GameItem.Instance.itemInfoList)
        {
            GameObject go = Instantiate(itemHelpCell);
            go.transform.parent = itemHelpPanel.transform;
            Image image = go.GetComponentsInChildren<Image>()[1];
            TextMeshProUGUI text = go.GetComponentInChildren<TextMeshProUGUI>();
            image.sprite = info.icon;
            text.text = info.description;
        }
    }
}
