using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Requirement : Object,Completable {
    public virtual bool IsCompleted { get { return true; } set { if (RequirementCompleteCallback != null) RequirementCompleteCallback(); } }
    public event System.Action RequirementCompleteCallback;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
