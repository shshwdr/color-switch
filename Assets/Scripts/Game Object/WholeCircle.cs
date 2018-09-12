using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WholeCircle : MonoBehaviour {
    public bool shouldChangeChildren;
    public bool willChange;
    public GameObject bombPrefab;
    public GameObject itemObject;
    public GameObject monsterObject;
	// Use this for initialization
	void Start () {
        Init();
	}

    public void Init()
    {
        if (shouldChangeChildren)
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

    public void Bomb()
    {
        DeactiveChildren();
        GameObject bomb = Instantiate(bombPrefab);
        bomb.transform.parent = transform;
        bomb.transform.localPosition = Vector3.zero;
        AnimatorClipInfo[] clipInfo = bomb.GetComponentInChildren<Animator>().GetCurrentAnimatorClipInfo(0);
        float clipLength = clipInfo[0].clip.length;
        Destroy(bomb, clipLength);
    }

    public void ReactiveChildren()
    {
        foreach (Transform trans in transform)
        {
            trans.gameObject.SetActive(true);
        }
    }

    public void DeactiveChildren()
    {
        foreach (Transform trans in transform)
        {
            trans.gameObject.SetActive(false);
        }
    }

    public void SetColor(GameColorEnum[] colors)
    {
        Init();
        CirclePart[] parts = GetComponentsInChildren<CirclePart>();
        
        for(int i = 0;i<4;i++)
        {
            GameColor gm = parts[i].GetComponent<GameColor>();
            gm.gameColor = colors[i];
        }
        GameColor[] colorManagers = GetComponentsInChildren<GameColor>();

        for (int i = 0; i < colorManagers.Length; i++)
        {
            colorManagers[i].Init();
        }
    }

    // Update is called once per frame
    void Update () {
		if (Camera.main.transform.position.y - 7 > transform.position.y)
        {
            transform.parent.gameObject.SetActive(false);
        }
        //else if (Camera.main.transform.position.y + 7 > transform.position.y)
        //{
        //    transform.parent.gameObject.SetActive(true);
        //}
    }
}
