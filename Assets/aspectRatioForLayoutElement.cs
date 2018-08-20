using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class aspectRatioForLayoutElement : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float ph = 800;
        float pw = 500;
        float h = transform.parent.GetComponent<RectTransform>().rect.height;
        float w = pw * h / ph;
        GetComponent<LayoutElement>().preferredWidth = w;
        GetComponent<RectTransform>().sizeDelta = new Vector2(w, h);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
