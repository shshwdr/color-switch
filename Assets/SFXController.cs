using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : Singleton<SFXController> {
    AudioSource audioSource;

    public AudioClip gameover;
    public AudioClip buttonClick;
    public AudioClip swoosh;

    // Use this for initialization
    void Start()
    {
        audioSource = GameObject.Find("SFX").GetComponent<AudioSource>();
        ChangeVolume(PlayerPrefs.GetFloat(CSConstant.SFXVolumePref, 1));
    }

    public void ButtonClick()
    {
        audioSource.clip = buttonClick;
        audioSource.Play();
    }

    public void GameOver()
    {
        audioSource.clip = gameover;
        audioSource.Play();
    }

    public void Swoosh()
    {
        audioSource.clip = swoosh;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
