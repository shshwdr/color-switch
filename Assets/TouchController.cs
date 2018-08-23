using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{

    Vector3 lastPosition;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameLogicManager.Instance.isPaused)
        {
            return;
        }
        //#if !UNITY_EDITOR
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase != TouchPhase.Began)
            {
                return;
            }
            //Your raycast handling
            Vector3 mousePosition = touch.position;
            //CSUtil.LOG("screen touched " + mousePosition);
            mousePosition = new Vector3(mousePosition.x, mousePosition.y, 10);
            RaycastHit2D[] vHits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(mousePosition), Vector2.zero);
            foreach (RaycastHit2D vhit in vHits)
            {
                if (vhit.transform.tag == "wholeCircle")
                {
                    (GameLogicManager.Instance.player).MoveToTarget(vhit.collider.gameObject);
                }
            }
        }
        //#endif

        if (Input.GetMouseButtonDown(0))
        {
            // Your raycast handling
            Vector3 mousePosition = Input.mousePosition;
            //CSUtil.LOG("mouse click " + mousePosition);
            mousePosition = new Vector3(mousePosition.x, mousePosition.y, 10);
            RaycastHit2D[] vHits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(mousePosition), Vector2.zero);
            foreach (RaycastHit2D vhit in vHits)
            {
                WholeCircle wc = vhit.transform.GetComponent<WholeCircle>();
                if (wc)
                {
                    if (wc.isActive())
                    {
                        if (GameLogicManager.Instance.player.MoveToTarget(vhit.collider.gameObject))
                        {
                            lastPosition = GameLogicManager.Instance.player.transform.position;
                        }
                    }
                    else
                    {
                       // CSUtil.LOG("this circle is invisible!");
                        //achievement: invisible target
                    }
                
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            //TODO: add a cheat class for this
            if(GameLogicManager.Instance.player.cheatDontDie)
            {
                GameLogicManager.Instance.player.transform.position = lastPosition;
                GameLogicManager.Instance.player.resetHittedPart();
            }
        }
    }
    
}
