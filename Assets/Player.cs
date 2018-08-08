using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Singleton<Player>
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

    float originScale;
    int currentScaleLevel= 2;
    float[] scaleLevels = { 0.3f, 0.7f, 1f, 1.2f, 1.5f };

    public bool isGameOver;
    public GameColor gameColor;
    Moveable moveable;

    HashSet<GameObject> hittedCircle;
    List<GameObject> hittedPart;
    GameObject gottenItem;


    //items
    bool willTransportNext;

    public float hp = 3;
    public float maxHP = 6;

    public bool gameStarted = false;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        ChangeColor(GameColor.yellow);
        originPosition = transform.position;
        CSUtil.LOG(originPosition);
        moveable = GetComponent<Moveable>();
        hittedCircle = new HashSet<GameObject>();
        hittedPart = new List<GameObject>();
        originScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            return;
        }
        //if (!canBeSeenByCamera())
        //{
        //    GameOver();
        //}
        //if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        //      {
        //          rb.velocity = Vector2.up * jumpForce;
        //      }
    }

    private bool canBeSeenByCamera()
    {

        return GetComponent<Renderer>().isVisible;
    }

    void SetRandomColor()
    {
        GameColor c = (GameColor)Random.Range(0, 4);
        ChangeColor(c);
    }

    public void ChangeColor(GameColor c)
    {
        gameColor = c;
        CSUtil.LOG("changed color to "+(int)c);
        sr.color = colorList[(int)c];
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (isGameOver)
        {
            return;
        }
        Debug.Log(col);
        if (decideByTheFirstHit&& col.transform.parent&&hittedCircle.Contains(col.transform.parent.gameObject))
        {
            return;
        }
        GameColorManager script = col.gameObject.GetComponent<GameColorManager>();
        CirclePart cp = col.gameObject.GetComponent<CirclePart>();
        if (script && cp)
        {
            GameColor c = script.gameColor;
            
            if (cp.willChange)
            {
                ChangeColor(c);
            }
            else
            {
                if (c != gameColor)
                {
                    lossHP();
                    if (isDead())
                    {
                        GameOver();
                    }
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
            if (decideByTheFirstHit)
            {
                hittedCircle.Add(col.transform.parent.gameObject);
            }

            //get item if exist
            GameItemManager item = col.transform.parent.GetComponentInChildren<GameItemManager>();
            if (item && item.gameObject.activeSelf)
            {
                GameItem.GetItem(item.itemEnum);
                item.gameObject.SetActive(false);
                gottenItem = item.gameObject;
            }
        }
        else
        {
            //hit on wholeCircle
            //CSUtil.ERROR("item is not color changer and does not have colorManager on it");

        }


    }

    void GameOver()
    {
        if (isGameOver)
        {
            return;
        }
        SFXController.Instance.GameOver();
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
        isGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public bool MoveToTarget(Vector3 target)
    {
        gameStarted = true;
        if (willTransportNext)
        {
            willTransportNext = false;
            transform.position = new Vector3(target.x, target.y, transform.position.z);
            //achievement
        }
        if (shouldDestroyPart)
        {
            foreach (GameObject go in hittedPart)
            {
                Destroy(go);
            }
            hittedPart.Clear();
        }
        Destroy(gottenItem);
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
        currentScaleLevel = Mathf.Max(0, currentScaleLevel - 1);
        float scale = scaleLevels[currentScaleLevel]*originScale;
        gameObject.transform.localScale = new Vector3(scale, scale, scale);
    }
    public void EnlargeBall()
    {
        currentScaleLevel = Mathf.Min(4, currentScaleLevel + 1);
        float scale = scaleLevels[currentScaleLevel] * originScale;
        gameObject.transform.localScale = new Vector3(scale, scale, scale);
    }

    public void Transport()
    {
        willTransportNext = true;
    }

    public void SlowDown()
    {
        moveable.Slowdown();
    }

    public void Speedup()
    {
        moveable.Speedup();
    }

    public void Bomb()
    {
        GameObject go = hittedPart[hittedPart.Count - 1].transform.parent.gameObject;
        WholeCircle wc = go.GetComponent<WholeCircle>();
        wc.DeactiveChildren();
    }

    public void gainHP(float gainedHP = 1)
    {
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
}
