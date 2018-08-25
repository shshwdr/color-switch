using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Rotator : MonoBehaviour {
    
    public float speed = 100f;//100 degree every second
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0f, 0f, speed * Time.deltaTime);
	}


}
