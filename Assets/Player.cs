using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public List<Color> colorList;
    public float jumpForce = 10f;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    GameColor gameColor;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        SetRandomColor();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
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
                    Debug.Log("game over");
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
}
