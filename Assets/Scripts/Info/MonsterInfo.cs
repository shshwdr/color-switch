using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterInfo {
    public string identifier;
    public string description;
    public string hp;
    public string attack;
    public string hitSfx;
    public int hpValue { get {
            string[] split = hp.Split('|');
            if (split.Length == 1)
            { return int.Parse(hp); }
            int randValue = Random.Range(int.Parse(split[0]), int.Parse(split[1])+1);
            return randValue;
        } }
    public int attackValue
    {
        get
        {
            string[] split = attack.Split('|');
            if (split.Length == 1)
            { return int.Parse(attack); }
            int randValue = Random.Range(int.Parse(split[0]), int.Parse(split[1])+1);
            return randValue;
        }
    }
    public Sprite icon {
        get
        {
            MonsterEnum monsterEnum = (MonsterEnum)System.Enum.Parse(typeof(MonsterEnum), identifier);
            return ResourceManager.Instance.monsterSprite[(int)monsterEnum];
        }

    }

}
