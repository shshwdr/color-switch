using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicManager : Singleton<GameLogicManager> {
    public Player player;
    int pauseValue;
    public bool isPaused { get { return pauseValue > 0; } }

    public void BlockTouch()
    {
        pauseValue++;
    }
    public void UnblockTouch()
    {
        pauseValue--;
    }
    public void Pause()
    {
        Time.timeScale = 0;
        pauseValue++;
    }



    public void Resume()
    {
        Time.timeScale = 1;
        pauseValue--;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
