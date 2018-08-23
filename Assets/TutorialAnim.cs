using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAnim : MonoBehaviour {
    public GameObject circleObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayerMoveToCircle()
    {
        //(TutorialGameLogicManager.Instance.player).MoveToTarget(circleObject);
    }
    public void ResetAnim()
    {
        //TutorialGameLogicManager.Instance.player.resetAnim
    }
}
