using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameColor { cyan, yellow, meganta, pink, none };

public class GameColorManager : MonoBehaviour {
    public GameColor gameColor;
    public int index;
    SpriteRenderer sr;
    // Use this for initialization
    void Start () {
        sr = GetComponent<SpriteRenderer>();
        switch (gameColor)
        {
            case GameColor.none:
                gameObject.SetActive(false);
                break;
            //case GameColor.cyan:
                
            //    break;
            //case GameColor.yellow:
            //    sr.sprite = ResourceManager.Instance.circleSprite[1];
            //    break;
            //case GameColor.pink:
            //    sr.sprite = ResourceManager.Instance.circleSprite[2];
            //    break;
            //case GameColor.meganta:
            //    sr.sprite = ResourceManager.Instance.circleSprite[3];
            //    break;
            default:
                sr.sprite = ResourceManager.Instance.circleSprite[(int)gameColor];
                transform.Rotate(new Vector3(0, 0, ( - index) * 90));
                //CSUtil.ERROR("game color is an invalid value");
                break;

            
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
