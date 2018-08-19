using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestoryManager : MonoBehaviour {
    public GameObject prefab;
	// Use this for initialization
	void Start () {
		if(FindObjectsOfType(typeof(GooglePlayManager)).Length == 0)
        {
            Instantiate(prefab);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
