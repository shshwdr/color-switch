using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {
    public Transform player;
    private Player playerScript;
	// Use this for initialization
	void Start () {
        playerScript = player.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerScript.isGameOver)
        {
            transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
        }
        else
        {
            if (player.position.y > transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
            }
        }
	}
}
