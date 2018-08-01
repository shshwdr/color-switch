using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WholeCircle : MonoBehaviour {
    public bool shouldChangeChildren;
    public bool willChange;
	// Use this for initialization
	void Start () {
		if(shouldChangeChildren)
        {
            foreach (CirclePart cp in GetComponentsInChildren<CirclePart>())
            {
                cp.SetWillChange(willChange);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
