﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

    Slider bgSlider;
    Slider sfxSlider;
    // Use this for initialization
    void Start () {
        bgSlider = GameObject.Find("BGSlider").GetComponent<Slider>();
        sfxSlider = GameObject.Find("SFXSlider").GetComponent<Slider>();
        bgSlider.value = PlayerPrefs.GetFloat(CSConstant.BGVolumePref, 1);
        sfxSlider.value = PlayerPrefs.GetFloat(CSConstant.SFXVolumePref, 1);
        BGSliderValueChanged();
        SFXSliderDrop();

    }

    public void BGSliderValueChanged()
    {
        BackgroundMusic.Instance.ChangeVolume(bgSlider.value);
        PlayerPrefs.SetFloat(CSConstant.BGVolumePref, bgSlider.value);
    }

    public void SFXSliderDrop()
    {
        SFXController.Instance.ChangeVolume(sfxSlider.value);
        PlayerPrefs.SetFloat(CSConstant.SFXVolumePref, sfxSlider.value);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
