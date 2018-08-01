using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceBehavior : MonoBehaviour {
    private static InstanceBehavior THE_INSTANCE;
    public InstanceBehavior()
    {
        THE_INSTANCE = this;

    }
    public static InstanceBehavior Instance
    {
        get
        {
            return THE_INSTANCE;
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
