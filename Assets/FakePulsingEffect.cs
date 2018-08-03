using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePulsingEffect : MonoBehaviour {
    public float pulsingTime = 0.5f;
    public float scaleBy = 1.0f;
    float currentTime;
    SpriteRenderer sr;
	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
        if (currentTime >= pulsingTime)
        {
            currentTime = 0;
            transform.localScale = new Vector3(1, 1, 1);
            sr.color = new Color(sr.color.r, sr.color.r, sr.color.r, 1);
        }
        else
        {
            float ratio = currentTime * currentTime / pulsingTime / pulsingTime;
            transform.localScale = new Vector3(1, 1, 1) + new Vector3(scaleBy, scaleBy, scaleBy)*ratio;
            sr.color = new Color(sr.color.r, sr.color.r, sr.color.r, 1-ratio);
        }
	}
}
