using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour {

    Vector3 direction;
    Vector3 target;
    float speed;
    public float moveTime = 0.5f;
    bool isMoving;


    public void MoveTo(Vector3 t)
    {
        if (!isMoving)
        {
            target = t;
            target = new Vector3(target.x, target.y, transform.position.z);
            Vector3 move = target - transform.position;
            
            direction = move.normalized;
            speed = move.magnitude / moveTime;
            isMoving = true;
            //CSUtil.LOG("start moving, direction: " + direction + "speed: " + speed);
            
        } else
        {
            //achievement: don't too rush
            //CSUtil.LOG("is moving");
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isMoving)
        {
            transform.position = transform.position + direction * speed * Time.deltaTime;
            if (CSMath.Vector3Equal(transform.position, target))
            {
                //CSUtil.LOG("Arrive target" + target);
                isMoving = false;
                transform.position = target;
                //achivement: keep jumping
            }
        }
	}

    public void KeepMoving(Vector3 dir,float sp = 5.0f)
    {
        target = CSMath.Vector3Inf;
        direction = dir.normalized;
        speed = sp;
    }

    public void StopMoving()
    {
        isMoving = false;
    }
}
