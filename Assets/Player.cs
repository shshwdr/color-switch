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

    public bool cheatDontDie;

    public bool isGameOver;
    GameColor gameColor;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        SetRandomColor();
        originPosition = transform.position;
        CSUtil.LOG(originPosition);
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
        if (cheatDontDie)
        {
            return;
        }
        gameView.GameOver();
        isGameOver = true;
    }

    public void Restart()
    {
        gameView.Restart();
        isGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MoveToTarget(Vector3 target)
    {
        transform.position = new Vector3(target.x, target.y, transform.position.z);
    }
}
