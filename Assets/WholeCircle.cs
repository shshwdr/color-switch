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

    public bool isActive()
    {
        foreach(Transform trans in transform)
        {
            if (trans.gameObject.activeSelf)
            {
                return true;
            }
        }
        return false;
    }

    public void DeactiveChildren()
    {
        foreach (Transform trans in transform)
        {
            trans.gameObject.SetActive(false);
        }
    }

    public void SetColor(GameColor[] colors)
    {
        CirclePart[] parts = GetComponentsInChildren<CirclePart>();
        
        for(int i = 0;i<4;i++)
        {
            GameColorManager gm = parts[i].GetComponent<GameColorManager>();
            gm.gameColor = colors[i];
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
