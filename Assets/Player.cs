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

    public bool isGameOver;
    public GameColor gameColor;
    Moveable moveable;

    HashSet<GameObject> hittedCircle;
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

    void ChangeColor(GameColor c)
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
        if (decideByTheFirstHit&&hittedCircle.Contains(col.transform.parent.gameObject))
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
                    GameOver();
                }
                else
                {
                    //achievement
                }
            }
            if(shouldDestroyPart)
            {
                Destroy(col.gameObject);
            }
            if (decideByTheFirstHit)
            {
                hittedCircle.Add(col.transform.parent.gameObject);
            }
            //gameColor = c;
            //Debug.Log(c);
            //sr.color = colorList[(int)c];
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
        CSUtil.LOG("game over");
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
        //transform.position = new Vector3(target.x, target.y, transform.position.z);
        if (decideByTheFirstHit)
        {
            hittedCircle.Clear();
        }
        return moveable.MoveTo(target);
        
    }
}
