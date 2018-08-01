using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour {
    AudioSource audioSource;
    private static BackgroundMusic THE_INSTANCE;

    public BackgroundMusic()
    {
        THE_INSTANCE = this;

    }

    //void Awake()
    //{
    //    DontDestroyOnLoad(gameObject);
    //}

    public static BackgroundMusic Instance
    {
        get
        {
            return THE_INSTANCE;
        }
    }
    // Use this for initialization
    void Start () {
        audioSource = GameObject.Find("BackgroundMusic"). GetComponent<AudioSource>();
        ChangeVolume(PlayerPrefs.GetFloat(CSConstant.BGVolumePref, 1));
	}



    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }
	
    public void Replay()
    {
        audioSource.Play();
    }

	// Update is called once per frame
	void Update () {
		
	}
}
