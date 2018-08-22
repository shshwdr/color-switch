﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GamePanelViewController : DefaultViewController {
    TextMeshProUGUI heartAmountText;
    TextMeshProUGUI goldAmountText;
    TextMeshProUGUI levelAmountText;
    public GameObject pausePanel;
    // Use this for initialization

    protected override void Awake()
    {
    }
    void Start()
    {
        heartAmountText = GameObject.Find("heartAmount").GetComponent<TextMeshProUGUI>();
        goldAmountText = GameObject.Find("goldAmount").GetComponent<TextMeshProUGUI>();
        levelAmountText = GameObject.Find("levelAmount").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    override protected void Update()
    {
        base.Update();
        //temp!
        goldAmountText.text = CurrencyManager.Instance.GetCurrencyAount(CSConstant.GOLD).ToString();
        heartAmountText.text = "X"+((int)Player.Instance.hp).ToString();
        levelAmountText.text = "Lev "+(((int)Player.Instance.maxY) / 10 + 1).ToString();
	}

    public void Pause()
    {
        SFXController.Instance.ButtonClick();
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        Player.Instance.isPaused = true;
    }

    public override void Back()
    {
        base.Back();
        Pause();
    }
    

    public void LossHP()
    {

    }
}
