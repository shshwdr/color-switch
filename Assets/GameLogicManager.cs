using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicManager : Singleton<GameLogicManager> {
    public Player player;

    public bool isPaused;
    public void Pause()
    {
        Time.timeScale = 0;
        isPaused = true;
    }



    public void Resume()
    {
        Time.timeScale = 1;
        isPaused = false;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
