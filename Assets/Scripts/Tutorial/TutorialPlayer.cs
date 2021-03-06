﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayer : Player
{
    // Use this for initialization
    //infinite hp

    public void ResetAnim()
    {
        transform.position = originPosition;
        ChangeColor(GameColorEnum.yellow);
    }


    override protected void InitAbility()
    {
        string currentAbilityString = "normal";
        abilityBehavior = AbilityBehavior.CreateAbilityBehavior(currentAbilityString);
    }

    // Update is called once per frame
    void Update()
    {

    }

    override protected void GameOver()
    {
        return;
    }

    protected override void HitWontChangePartWithDifferentColor()
    {
        ShowLossHP();
            SFXManager.Instance.PlaySFX(SFXEnum.hitOnPart);
    }

    void ShowLossHP()
    {
        ItemText.CreateText(CachePoolManager.Instance.tutorialPopupText,"-1 HP", transform);
    }

    protected override void HitWontChangePartWithSameColor()
    {
        ItemText.CreateText(CachePoolManager.Instance.tutorialPopupText, "SAFE!", transform);
    }
}
