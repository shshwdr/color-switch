using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {
    public float scrollSpeed = 0.1f;
	// Use this for initialization
	void Start () {
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
