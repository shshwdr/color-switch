using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public List<Color> colorList;
    public float jumpForce = 10f;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public MainGameView gameView;
    public Vector3 originPosition;
    public bool shouldDestroyPart;
    public bool cheatDontDie;
    public bool decideByTheFirstHit;
    public SpriteRenderer backgroundSprite;

    public AbilityBehavior abilityBehavior;

    float originScale;
    int currentScaleLevel= 2;
    float[] scaleLevels = { 0.3f, 0.7f, 1f, 1.2f, 1.5f };

    public bool isGameOver;
    public GameColorEnum gameColor;
    Moveable moveable;

    HashSet<GameObject> hittedCircle;
    List<GameObject> hittedPart;
    GameObject gottenItem;

    bool gotHurtInThisJump;


    //items
    public GameObject targetObject;
    public bool willTeleportNext;
    public bool willTeleportThis;

    public float hp = 3;
    public float maxHP = 6;

    public bool gameStarted = false;

    public float maxY = 0;

    public delegate void OnPositionChangeDelegate(Vector3 pos);
    public event OnPositionChangeDelegate OnPositionChange;


    // Use this for initialization
    protected void Start()
    {
        InitAbility();
        initPlayer();
        abilityBehavior.InitPlayer();
    }

    protected void initPlayer()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        ChangeColor(GameColorEnum.yellow);
        originPosition = transform.position;
        CSUtil.LOG(originPosition);
        moveable = GetComponent<Moveable>();
        hittedCircle = new HashSet<GameObject>();
        hittedPart = new List<GameObject>();
        originScale = transform.localScale.x;
    }

    virtual protected void InitAbility()
    {
        string currentAbilityString = AbilityManager.Instance.currentlyUsingBall;
        abilityBehavior = AbilityBehavior.CreateAbilityBehavior(currentAbilityString);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            return;
        }
        maxY = Mathf.Max(maxY, transform.position.y);
        if (OnPositionChange != null)
        {
            //only send when position changes?
            OnPositionChange(transform.position);
        }
    }

    private bool canBeSeenByCamera()
    {

        return GetComponent<Renderer>().isVisible;
    }

    void SetRandomColor()
    {
        GameColorEnum c = (GameColorEnum)Random.Range(0, 4);
        ChangeColor(c);
    }

    public void ChangeColor(GameColorEnum c)
    {
        gameColor = c;
        CSUtil.LOG("changed color to "+(int)c);
        sr.color = colorList[(int)c];
    }

    protected virtual void HitWontChangePartWithDifferentColor()
    {
        if (!gotHurtInThisJump)
        {
            gotHurtInThisJump = true;
            lossHP();
            Camera.main.GetComponent<FollowTarget>().ShakeCamera();
            if (isDead())
            {
                GameOver();
            }
            else
            {
                SFXManager.Instance.PlaySFX(SFXEnum.hitOnPart);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (isGameOver)
        {
            return;
        }
        Debug.Log(col);
        if (col.GetComponent<SpriteRenderer>()!=null && col.GetComponent<SpriteRenderer>().sortingLayerID!= GetComponent<SpriteRenderer>().sortingLayerID)
        {
            return;
        }
        if (decideByTheFirstHit&& col.transform.parent&&hittedCircle.Contains(col.transform.parent.gameObject))
        {
            return;
        }
        if (willTeleportThis)
        {
            return;
        }
        GameColor script = col.gameObject.GetComponent<GameColor>();
        CirclePart cp = col.gameObject.GetComponent<CirclePart>();
        if (script && cp)
        {
            GameColorEnum c = script.gameColor;
            
            if (cp.willChange)
            {
                ChangeColor(c);
            }
            else
            {
                if (c != gameColor)
                {
                    HitWontChangePartWithDifferentColor();
                }
                else
                {
                    //achievement
                }
            }
            if (shouldDestroyPart)
            {
                col.gameObject.SetActive(false);
                hittedPart.Add(col.gameObject);
            }
            if (!abilityBehavior.WouldDestroyMultiplePartsOnOneCircle)
            {
                hittedCircle.Add(col.transform.parent.gameObject);
            }

            //get item if exist
            GameItem item = col.transform.parent.parent.GetComponentInChildren<GameItem>();
            UseItem(item);
        }
        else
        {
            //hit on wholeCircle
            //CSUtil.ERROR("item is not color changer and does not have colorManager on it");

        }
    }

    void UseItem(GameItem item)
    {
        if (item && item.gameObject.activeSelf)
        {
            string itemName = GameItemManager.GetItem(item.itemEnum);

            //put this into itemTextClass
            GameObject go = CachePoolManager.Instance.ItemText();
            ItemText itemText = go.GetComponent<ItemText>();
            itemText.Initialize(itemName, item.transform.position);

            item.gameObject.SetActive(false);
            gottenItem = item.gameObject;
        }
    }

    void ShowItemText(string text, GameObject circle)
    {
        //instantiate a text on circle
    }

    virtual protected void GameOver()
    {
        if (isGameOver)
        {
            return;
        }
        SFXManager.Instance.PlaySFX(SFXEnum.gameover);
        if (cheatDontDie)
        {
            moveable.StopMoving();
            return;
        }
        gameView.GameOver();
        isGameOver = true;
        moveable.KeepMoving(new Vector3(0, -1, 0));
        //CSUtil.LOG("game over");
        //leaderboard update
        //achievement: die
    }

    public void Restart()
    {
        gameView.Restart();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnBecameInvisible()
    {
        GameOver();
    }

    public bool MoveToTarget(GameObject target_object)
    {
        Vector3 target = target_object.transform.position;
        targetObject = target_object;
        gotHurtInThisJump = false;
        gameStarted = true;
        if (willTeleportNext)
        {
            willTeleportThis = willTeleportNext;
            willTeleportNext = false;
            ParticleEffectManager.Instance.playParticleEffect(transform.position, ParticleEffectEnum.teleport);
            Vector3 teleportTarget = new Vector3(target.x, target.y, transform.position.z);
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0);

            SFXManager.Instance.PlaySFX(SFXEnum.teleport);
            ParticleEffectManager.Instance.playParticleEffect(teleportTarget, ParticleEffectEnum.teleport);
            //transform.position = teleportTarget;
            //achievement
        } else
        {
            SFXManager.Instance.PlaySFX(SFXEnum.swoosh);
        }
        if (shouldDestroyPart)
        {
            foreach (GameObject go in hittedPart)
            {
                //Destroy(go);
            }
            hittedPart.Clear();
        }
        if (gottenItem)
        {
            gottenItem.gameObject.SetActive(false);
        }
        if (decideByTheFirstHit)
        {
                hittedCircle.Clear();
        }
        return moveable.MoveTo(target);    
    }

    public void resetHittedPart()
    {
        if (shouldDestroyPart)
        {
            foreach (GameObject go in hittedPart)
            {
                go.SetActive(true);
            }
            hittedPart.Clear();
        }
        gottenItem.SetActive(true);
    }

    public void MinishBall()
    {
        SFXManager.Instance.PlaySFX(SFXEnum.possitive);
        currentScaleLevel = Mathf.Max(0, currentScaleLevel - 1);
        float scale = scaleLevels[currentScaleLevel]*originScale;
        gameObject.transform.localScale = new Vector3(scale, scale, scale);
    }
    public void EnlargeBall()
    {
        SFXManager.Instance.PlaySFX(SFXEnum.negative);
        currentScaleLevel = Mathf.Min(4, currentScaleLevel + 1);
        float scale = scaleLevels[currentScaleLevel] * originScale;
        gameObject.transform.localScale = new Vector3(scale, scale, scale);
    }

    public void Teleport()
    {
        willTeleportNext = true;
    }
    public void TeleportArrived()
    {
        GameLogicManager.Instance.player.willTeleportThis = false;
        //ParticleEffectManager.Instance.playParticleEffect(transform.position, ParticleEffectEnum.teleport);
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1);
        GameItem item = targetObject.GetComponentInChildren<WholeCircle>().itemObject.GetComponent<GameItem>();
        UseItem(item);
    }

    public void SlowDown()
    {
        SFXManager.Instance.PlaySFX(SFXEnum.negative);
        moveable.Slowdown();
    }

    public void Speedup()
    {
        SFXManager.Instance.PlaySFX(SFXEnum.possitive);
        moveable.Speedup();
    }

    public void Bomb()
    {
        GameObject go = hittedPart[hittedPart.Count - 1].transform.parent.gameObject;
        WholeCircle wc = go.GetComponent<WholeCircle>();
        wc.Bomb();
        SFXManager.Instance.PlaySFX(SFXEnum.bomb);
        Camera.main.GetComponent<FollowTarget>().ShakeCamera();
    }

    public void gainHP(float gainedHP = 1)
    {
        SFXManager.Instance.PlaySFX(SFXEnum.possitive);
        hp = Mathf.Min(hp + gainedHP, maxHP);
    }

    public void lossHP(float gainedHP = 1)
    {
        hp = Mathf.Max(hp - gainedHP, 0);
    }
    
    public bool isDead()
    {
        return hp <= 0.1f;
    }

    public void ScaleMoveTimeBase(float scale)
    {
        moveable.ScaleMoveTimeBase(scale);
    }
}
