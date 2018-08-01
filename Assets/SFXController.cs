using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour {
    AudioSource audioSource;

    public AudioClip gameover;
    public AudioClip buttonClick;
    public AudioClip swoosh;

    private static SFXController THE_INSTANCE;

    public SFXController()
    {
        THE_INSTANCE = this;

    }

    //void Awake()
    //{
    //    DontDestroyOnLoad(gameObject);
    //}

    public static SFXController Instance
    {
        get
        {
            return THE_INSTANCE;
        }
    }
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

	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
