using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayer : Player
{
    // Use this for initialization
    //infinite hp

    public void ResetAnim()
    {
        transform.position = originPosition;
        ChangeColor(GameColor.yellow);
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
}
