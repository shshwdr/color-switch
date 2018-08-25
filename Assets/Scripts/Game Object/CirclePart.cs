using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePart : MonoBehaviour {

    public bool willChange;
    

	// Use this for initialization
	void Start () {
		
	}

    public void SetWillChange(bool will)
    {
        willChange = will;
        transform.GetChild(0).gameObject.SetActive(willChange);

  
    }
}
