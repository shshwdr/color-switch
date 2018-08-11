using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItem : MonoBehaviour {

	static public string GetItem(GameItemEnum itemEnum)
    {
        int rand;
        FollowTarget ft = Camera.main.GetComponent<FollowTarget>();
        //CSUtil.LOG("get item " + itemEnum);
        switch (itemEnum)
        {
            case GameItemEnum.smallBall:
                Player.Instance.MinishBall();
                break;
            case GameItemEnum.megaBall:
                Player.Instance.EnlargeBall();
                break;
            case GameItemEnum.heart:
                Player.Instance.gainHP();
                break;
            case GameItemEnum.gold:
                rand = Random.Range(1, 5);
                CurrencyManager.Instance.AddCurrencyAmount(CSConstant.GOLD, rand);
                break;
            case GameItemEnum.randomColor:
                SFXController.Instance.PlaySFX(SFXEnum.possitive);
                GameColor c = (GameColor)Random.Range(0, 4);
                Player.Instance.ChangeColor(c);
                break;
            case GameItemEnum.bomb:
                Player.Instance.Bomb();
                break;
            case GameItemEnum.teleport:
                Player.Instance.Teleport();
                break;
            case GameItemEnum.ballSlowDown:
                Player.Instance.SlowDown();
                break;
            case GameItemEnum.ballSpeedup:
                Player.Instance.Speedup();
                break;
            case GameItemEnum.screenSlowDown:
                SFXController.Instance.PlaySFX(SFXEnum.possitive);
                ft.Slowdown();
                break;
            case GameItemEnum.screenSpeedup:
                SFXController.Instance.PlaySFX(SFXEnum.negative);
                ft.Speedup();
                break;
            case GameItemEnum.random:
                rand = Random.Range(0, (int)GameItemEnum.random);
                return GetItem((GameItemEnum)rand);
        }
        return itemEnum.ToString();
    }
}
