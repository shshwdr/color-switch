using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Monster : MonoBehaviour {

    public int hp;
    public int attack;
    public bool isDead;
    public float dropingSpeed = 10f;

    public SpriteRenderer monsterSpriteRender;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI attackText;

    public void Init(MonsterInfo monsterInfo)
    {
        hp = monsterInfo.hpValue;
        attack = monsterInfo.attackValue;
        monsterSpriteRender.sprite = monsterInfo.icon;
        UpdateState();
    }

    public void Init(int initialHp,int initialAttack)
    {
        hp = initialHp;
        attack = initialAttack;
        //monsterSpriteRender.sprite = sprite;
        UpdateState();
    }

    public void UpdateState()
    {
        hpText.text = hp.ToString();
        attackText.text = attack.ToString();
    }

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
