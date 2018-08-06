using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameItem { smallBall, megaBall, heart, gold, changeColor, bomb, transport };//random color, random

public class GameItemManager : MonoBehaviour {
    public GameItem item;
    SpriteRenderer sr;
    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = ResourceManager.Instance.itemSprite[(int)item];
    }

    // Update is called once per frame
    void Update () {
		
	}
}
