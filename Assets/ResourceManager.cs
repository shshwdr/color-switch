using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : Singleton<ResourceManager> {

    public Sprite[] circleSprite = new Sprite[4];
    public Sprite[] itemSprite;
    public GameObject[] ItemTextsPool;
    int currentItemTextIndex;
    public GameObject ItemPrefab;
    public GameObject ItemText()
    {
        GameObject go = ItemTextsPool[currentItemTextIndex];
        currentItemTextIndex = (currentItemTextIndex+1)% ItemTextsPool.Length;
        return go;
    }
    // Use this for initialization
    void Start () {
		foreach (GameObject go in ItemTextsPool)
        {
            go.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
