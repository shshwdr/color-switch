using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestoryManager : MonoBehaviour {
    public GameObject prefab;
	// Use this for initialization

    public void Init()
    {

        if (FindObjectsOfType(typeof(GooglePlayManager)).Length == 0)
        {
            Instantiate(prefab);
        }
    }
	void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
