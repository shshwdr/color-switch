using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
#if !UNITY_EDITOR
        if (Input.touchCount == 1)
        {
            // Your raycast handling
            RaycastHit2D[] vHits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero) ;
            foreach (RaycastHit2D vhit in vHits)
            {
                if (vhit.transform.tag == "wholeCircle")
                {
                    (Player.Instance).MoveToTarget(vhit.transform.position);
                }
            }
        }
#endif

        if (Input.GetMouseButtonDown(0))
        {
            // Your raycast handling
            RaycastHit2D[] vHits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            foreach (RaycastHit2D vhit in vHits)
            {
                if (vhit.transform.tag == "wholeCircle")
                {
                    (Player.Instance).MoveToTarget(vhit.transform.position);
                }
            }
        }
    }

}
