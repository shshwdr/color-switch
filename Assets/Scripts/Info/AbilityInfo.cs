using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityInfo {
    public string identifier;
    public string description;
    public string ability;
    public string name;
    public int cost;
    public Sprite icon {
        get
        {
            AbilityEnum itemEnum = (AbilityEnum)System.Enum.Parse(typeof(AbilityEnum), identifier);
            int index = (int)itemEnum;
            //test
            index = Mathf.Min(index, ResourceManager.Instance.abilitySprite.Length-1);
            return ResourceManager.Instance.abilitySprite[index];
        }

    }
}
