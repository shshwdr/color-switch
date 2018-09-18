using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Monster : MonoBehaviour {

    public int hp;
    public int attack;
    public bool isDead;
    public float dropingSpeed = 10f;
    public int currentHP;

    AudioSource audioSource;

    public SpriteRenderer monsterSpriteRender;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI attackText;
    MonsterInfo info;

    public void Init(MonsterInfo monsterInfo)
    {
        monsterSpriteRender.sprite = monsterInfo.icon;
        info = monsterInfo;
        Init(monsterInfo.hpValue, monsterInfo.attackValue);
        
    }

    public void Init(int initialHp,int initialAttack)
    {
        hp = initialHp;
        currentHP = hp;
        attack = initialAttack;
        //monsterSpriteRender.sprite = sprite;
        UpdateState();
    }

    public void GetDamage(int damage)
    {
        if (isDead)
        {
            return;
        }
        currentHP -= damage;
        UpdateState();
        //Debug.LogError(info.identifier+ " getDamage");
        SFXEnum sfxEnum = (SFXEnum)System.Enum.Parse(typeof(SFXEnum), "monsterHit");
        audioSource.clip = SFXManager.Instance.SfxClip(sfxEnum);
        //Debug.LogError("audioSource " + audioSource + " clip " + audioSource.clip);
        audioSource.Play();

        if (currentHP <= 0)
        {
            Dead();
        }

            
    }

    public void Dead()
    {
        isDead = true;
        //gameObject.SetActive(false);
    }

    public void UpdateState()
    {
        hpText.text = currentHP.ToString();
        attackText.text = attack.ToString();
    }

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
