using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class AbilityBehavior {

    public virtual void InitPlayer() { }

    public bool WouldDestroyMultiplePartsOnOneCircle
    {
        get
        { return true; }
    }

    static public AbilityBehavior CreateAbilityBehavior(string abilityString)
    {
        AbilityEnum parsed_enum = (AbilityEnum)System.Enum.Parse(typeof(AbilityEnum), abilityString);
        switch (parsed_enum)
        {
            case AbilityEnum.normal:
                return new NormalBallAbility();
            case AbilityEnum.fireBall:
                return new FireBallAbility();
            case AbilityEnum.lightningBall:
                break;
            case AbilityEnum.waterBall:
                break;
            case AbilityEnum.thiefBall:
                break;
            case AbilityEnum.lifeBall:
                break;
            case AbilityEnum.goldBall:
                break;
            case AbilityEnum.strongBall:
                break;
            case AbilityEnum.loveBall:
                break;
        }
        return new NormalBallAbility();
    }
}



public class NormalBallAbility : AbilityBehavior
{

}

public class FireBallAbility : AbilityBehavior
{
    public override void InitPlayer()
    {
        base.InitPlayer();
        Player.Instance.ScaleMoveTimeBase(0.5f);
        Player.Instance.backgroundSprite.sprite = ResourceManager.Instance.abilitySprite[1];
    }

    public new bool WouldDestroyMultiplePartsOnOneCircle
    {
        get
        { return false; }
    }
}


