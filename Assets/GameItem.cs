﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItem : MonoBehaviour {

	static public void GetItem(GameItemEnum itemEnum)
    {
        CSUtil.LOG("get item " + itemEnum);
        switch (itemEnum)
        {
            case GameItemEnum.smallBall:
                Player.Instance.MinishBall();
                break;
            case GameItemEnum.megaBall:
                Player.Instance.EnlargeBall();
                break;
            case GameItemEnum.heart:
                break;
            case GameItemEnum.gold:
                break;
            case GameItemEnum.randomColor:
                GameColor c = (GameColor)Random.Range(0, 4);
                Player.Instance.ChangeColor(c);
                break;
            case GameItemEnum.bomb:
                break;
            case GameItemEnum.transport:
                Player.Instance.Transport();
                break;
            case GameItemEnum.ballSlowDown:
                Player.Instance.SlowDown();
                break;
            case GameItemEnum.ballSpeedup:
                Player.Instance.Speedup();
                break;
            case GameItemEnum.screenSlowDown:
                break;
            case GameItemEnum.screenSpeedup:
                break;
            case GameItemEnum.random:
                int rand = Random.Range(0, (int)GameItemEnum.random);
                GetItem((GameItemEnum)rand);
                break;
        }
    }
}
