using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAnim : MonoBehaviour {
    public GameObject circleObject;
    public TutorialPlayer tutorialPlayer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayerMoveToCircle()
    {
        tutorialPlayer.MoveToTarget(circleObject);
    }
    public void ResetAnim()
    {
        tutorialPlayer.ResetAnim();
        circleObject.GetComponent<WholeCircle>().ReactiveChildren();
    }
}
