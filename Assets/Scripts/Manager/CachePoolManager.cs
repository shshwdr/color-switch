using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CachePoolManager : Singleton<CachePoolManager> {
    public GameObject[] ItemTextsPool;
    int currentItemTextIndex;
    public GameObject[] circlePool;
    int currentCircleIndex = 3;
    public GameObject ItemText()
    {
        GameObject go = ItemTextsPool[currentItemTextIndex];
        currentItemTextIndex = (currentItemTextIndex + 1) % ItemTextsPool.Length;
        return go;
    }
    public GameObject getCircle()
    {
        GameObject go = circlePool[currentCircleIndex];
        currentCircleIndex = (currentCircleIndex + 1) % circlePool.Length;
        return go;
    }
    // Use this for initialization
    void Start()
    {
        foreach (GameObject go in ItemTextsPool)
        {
            go.SetActive(false);
        }
    }
}
