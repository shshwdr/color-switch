using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameItemEnum { smallBall, megaBall, heart, gold, randomColor, bomb,
    teleport, ballSlowDown, ballSpeedup, screenSlowDown, screenSpeedup, random,};

public class GameItemManager : MonoBehaviour {
    public GameItemEnum itemEnum;
    SpriteRenderer sr;
    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Init();
        gameObject.SetActive(false);
    }

    public void Init()
    {
        sr.sprite = ResourceManager.Instance.itemSprite[(int)itemEnum];
    }

    // Update is called once per frame
    void Update () {
		
	}
}
