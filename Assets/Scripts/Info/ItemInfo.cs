using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo {
    public string identifier;
    public string description;
    public Sprite icon {
        get
        {
            GameItemEnum itemEnum = (GameItemEnum)System.Enum.Parse(typeof(GameItemEnum), identifier);
            return ResourceManager.Instance.itemSprite[(int)itemEnum];
        }

    }

}
