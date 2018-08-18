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
                return new LightningBallAbility();
            case AbilityEnum.waterBall:
                return new WaterBallAbility();
            case AbilityEnum.thiefBall:
                return new ThiefBallAbility();
            case AbilityEnum.lifeBall:
                return new LifeBallAbility();
            case AbilityEnum.goldBall:
                return new GoldBallAbility();
            case AbilityEnum.strongBall:
                return new StrongBallAbility();
            case AbilityEnum.loveBall:
                return new LoveBallAbility();
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


public class LightningBallAbility : AbilityBehavior
{
    public override void InitPlayer()
    {
        base.InitPlayer();
        Player.Instance.backgroundSprite.sprite = ResourceManager.Instance.abilitySprite[2];
    }
    
}

public class WaterBallAbility : AbilityBehavior
{
    public override void InitPlayer()
    {
        base.InitPlayer();
        Player.Instance.backgroundSprite.sprite = ResourceManager.Instance.abilitySprite[3];
    }
}

public class ThiefBallAbility : AbilityBehavior
{
    public override void InitPlayer()
    {
        base.InitPlayer();
        Player.Instance.backgroundSprite.sprite = ResourceManager.Instance.abilitySprite[4];
    }
}

public class LifeBallAbility : AbilityBehavior
{
    public override void InitPlayer()
    {
        base.InitPlayer();
        Player.Instance.backgroundSprite.sprite = ResourceManager.Instance.abilitySprite[5];
    }
}

public class GoldBallAbility : AbilityBehavior
{
    public override void InitPlayer()
    {
        base.InitPlayer();
        Player.Instance.backgroundSprite.sprite = ResourceManager.Instance.abilitySprite[6];
    }
}

public class StrongBallAbility : AbilityBehavior
{
    public override void InitPlayer()
    {
        base.InitPlayer();
        Player.Instance.backgroundSprite.sprite = ResourceManager.Instance.abilitySprite[7];
    }
}

public class LoveBallAbility : AbilityBehavior
{
    public override void InitPlayer()
    {
        base.InitPlayer();
        Player.Instance.backgroundSprite.sprite = ResourceManager.Instance.abilitySprite[8];
    }
}