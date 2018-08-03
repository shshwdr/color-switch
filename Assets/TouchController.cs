﻿using System.Collections;
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
        //#if !UNITY_EDITOR
        if (Input.touchCount == 1)
        {
            //Your raycast handling
            Vector3 mousePosition = Input.GetTouch(0).position;
            CSUtil.LOG("screen touched " + mousePosition);
            mousePosition = new Vector3(mousePosition.x, mousePosition.y, 10);
            RaycastHit2D[] vHits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(mousePosition), Vector2.zero);
            foreach (RaycastHit2D vhit in vHits)
            {
                if (vhit.transform.tag == "wholeCircle")
                {
                    (Player.Instance).MoveToTarget(vhit.transform.position);
                }
            }
        }
        //#endif

        if (Input.GetMouseButtonDown(0))
        {
            // Your raycast handling
            Vector3 mousePosition = Input.mousePosition;
            CSUtil.LOG("mouse click " + mousePosition);
            mousePosition = new Vector3(mousePosition.x, mousePosition.y, 10);
            RaycastHit2D[] vHits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(mousePosition), Vector2.zero);
            foreach (RaycastHit2D vhit in vHits)
            {
                if (vhit.transform.tag == "wholeCircle")
                {
                    lastPosition = Player.Instance.transform.position;
                    Player.Instance.MoveToTarget(vhit.transform.position);
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            //TODO: add a cheat class for this
            if(Player.Instance.cheatDontDie)
            {
                Player.Instance.transform.position = lastPosition;
            }
        }
    }
    
}
