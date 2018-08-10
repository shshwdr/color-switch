﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SFXEnum
{
    gameover,
    buttonClick,
    swoosh,
    hitOnPart,
    bomb,
    teleport,
    negative,
    possitive,
    gold,
    coin,
    purchase,
    bubble,
};

public class SFXController : Singleton<SFXController>
{
    AudioSource audioSource;

   
    public AudioClip[] clips;

    // Use this for initialization
    void Start()
    {
        audioSource = GameObject.Find("SFX").GetComponent<AudioSource>();
        ChangeVolume(PlayerPrefs.GetFloat(CSConstant.SFXVolumePref, 1));
    }

    public void ButtonClick()
    {
        audioSource.clip = clips[(int)SFXEnum.buttonClick];
        audioSource.Play();
    }

    public void PlaySFX(SFXEnum sfxEnum){
        audioSource.clip = clips[(int)sfxEnum];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
