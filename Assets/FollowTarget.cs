using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {
    public float scrollSpeed = 0.1f;
    public float[] speedArray = { 0.05f, 0.07f, 0.1f, 0.15f, 0.2f };
    int currentSpeedIndex = 2; 

	// Use this for initialization
	void Start () {
	}

    public void Speedup()
    {
        currentSpeedIndex =  Mathf.Min(currentSpeedIndex + 1, speedArray.Length - 1);
        scrollSpeed = speedArray[currentSpeedIndex];
    }

    public void Slowdown()
    {
        currentSpeedIndex = Mathf.Max(currentSpeedIndex - 1, 0);
        scrollSpeed = speedArray[currentSpeedIndex];
    }

    // Update is called once per frame
    void Update () {
        Vector3 playerPosition = Player.Instance.transform.position;
        if (Player.Instance.isGameOver)
        {
            transform.position = new Vector3(transform.position.x, playerPosition.y, transform.position.z);
        }
        else
        {
            if (Player.Instance.gameStarted)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + scrollSpeed * Time.deltaTime, transform.position.z);
            }
            if (playerPosition.y > transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, playerPosition.y, transform.position.z);
            }
        }
	}
}
