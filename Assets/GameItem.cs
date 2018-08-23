using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sinbad;

public class GameItem : Singleton<GameItem> {

    public List<ItemInfo> itemInfoList;

    private void Start()
    {
        ReadCSV();
    }
    void ReadCSV()
    {
        itemInfoList = CsvUtil.LoadObjects<ItemInfo>("item.csv");

    }

    static public string GetItem(GameItemEnum itemEnum)
    {
        int rand;
        FollowTarget ft = Camera.main.GetComponent<FollowTarget>();
        //CSUtil.LOG("get item " + itemEnum);
        Player player = GameLogicManager.Instance.player;
        switch (itemEnum)
        {
            case GameItemEnum.smallBall:
                player.MinishBall();
                break;
            case GameItemEnum.megaBall:
                player.EnlargeBall();
                break;
            case GameItemEnum.heart:
                player.gainHP();
                break;
            case GameItemEnum.gold:
                rand = Random.Range(1, 5);
                CurrencyManager.Instance.AddCurrencyAmount(CSConstant.GOLD, rand);
                SFXController.Instance.PlaySFX(SFXEnum.coin);
                break;
            case GameItemEnum.randomColor:
                SFXController.Instance.PlaySFX(SFXEnum.possitive);
                GameColor c = (GameColor)Random.Range(0, 4);
                player.ChangeColor(c);
                break;
            case GameItemEnum.bomb:
                player.Bomb();
                break;
            case GameItemEnum.teleport:
                player.Teleport();
                break;
            case GameItemEnum.ballSlowDown:
                player.SlowDown();
                break;
            case GameItemEnum.ballSpeedup:
                player.Speedup();
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
