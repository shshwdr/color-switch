using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItem : MonoBehaviour {

	static public void GetItem(GameItemEnum itemEnum)
    {
        switch (itemEnum)
        {
            case GameItemEnum.smallBall:
                Player.Instance.MinishBall();
                break;
            default:
                break;
        }
    }
}
