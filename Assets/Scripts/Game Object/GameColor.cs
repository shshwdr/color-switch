using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameColorEnum { cyan, yellow, meganta, pink, none };

public class GameColor : MonoBehaviour {
    public GameColorEnum gameColor;
    public int index;
    SpriteRenderer sr;
    bool hasFinishedStart;
    // Use this for initialization

    public void Init()
    {

        GameColor parent = transform.parent.GetComponent<GameColor>();
        //if parent is a color part, follow it's color
        if (parent)
        {
            gameColor = parent.gameColor;
        }
        switch (gameColor)
        {
            case GameColorEnum.none:
                gameObject.SetActive(false);
                break;
            default:
               // Debug.Log("index " + index);
                sr.sprite = ResourceManager.Instance.circleSprite[(int)gameColor];
                if (!hasFinishedStart)
                {
                    transform.Rotate(new Vector3(0, 0, (-index) * 90));
                }
                hasFinishedStart = true;
                //CSUtil.ERROR("game color is an invalid value");
                break;
        }
    }

    void Start () {
        sr = GetComponent<SpriteRenderer>();
        Init();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
