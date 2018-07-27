using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
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
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        SetRandomColor();
        originPosition = transform.position;
        Debug.Log(originPosition);
	}
	
	// Update is called once per frame
	void Update () {
        if (isGameOver)
        {
            return;
        }
        //if (!canBeSeenByCamera())
        //{
        //    GameOver();
        //}
		if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
	}

    private bool canBeSeenByCamera()
    {

        return GetComponent<Renderer>().isVisible;
    }

    void SetRandomColor()
    {
        GameColor c = (GameColor) Random.Range(0, 4);
        gameColor = c;
        Debug.Log((int)c);
        sr.color = colorList[(int)c];
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (isGameOver)
        {
            return;
        }
        Debug.Log(col);
        if (col.tag == "colorChanger")
        {
            SetRandomColor();
            Destroy(col.gameObject);
        }else
        {
            GameColorManager script = col.gameObject.GetComponent<GameColorManager>();
            if (script)
            {
                GameColor c = script.gameColor;
                if(c!=gameColor)
                {
                    GameOver();
                }
                //gameColor = c;
                //Debug.Log(c);
                //sr.color = colorList[(int)c];
            } else
            {
                Debug.LogError("item is not color changer and does not have colorManager on it");
            }
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
}
