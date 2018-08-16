using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityInfo {
    public string identifier;
    public string description;
    public string ability;
    public string name;
    public Sprite icon {
        get
        {
            GameItemEnum itemEnum = (GameItemEnum)System.Enum.Parse(typeof(GameItemEnum), identifier);
            return ResourceManager.Instance.itemSprite[(int)itemEnum];
        }

    }
}
