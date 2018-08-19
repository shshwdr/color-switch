using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameView : MonoBehaviour {
    public GameObject gameOverView;
	// Use this for initialization
	void Start () {
		
	}
	
    public void GameOver()
    {
        if (gameOverView)
        {
            gameOverView.SetActive(true);
        }
    }

    public void Restart()
    {
        gameOverView.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
