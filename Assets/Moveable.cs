using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour {

    Vector3 direction;
    Vector3 target;
    float speed;
    public float originMoveTime = 0.5f;

    public float currentMoveTime;
    int currentMoveTimeIndex = 2;
    public float moveTimeBase = 1.0f;
    public float[] moveTimeArray = { 0.3f, 0.4f, 0.5f, 0.6f, 0.7f };

    bool isMoving;


    public bool MoveTo(Vector3 t)
    {
        if (!isMoving)
        {
            target = t;
            target = new Vector3(target.x, target.y, transform.position.z);
            Vector3 move = target - transform.position;
            
            direction = move.normalized;
            speed = move.magnitude / currentMoveTime;
            isMoving = true;
            //CSUtil.LOG("start moving, direction: " + direction + "speed: " + speed);
            return true;

        } else
        {
            //achievement: don't too rush
            //CSUtil.LOG("is moving");
            return false;
        }
    }

    public void Slowdown()
    {
        currentMoveTimeIndex = Mathf.Min(4, currentMoveTimeIndex + 1);
        currentMoveTime = moveTimeArray[currentMoveTimeIndex]* moveTimeBase;
    }

    public void Speedup() {
        currentMoveTimeIndex = Mathf.Max(0, currentMoveTimeIndex - 1);
        currentMoveTime = moveTimeArray[currentMoveTimeIndex]* moveTimeBase;
    }

    public void ScaleMoveTimeBase(float scale)
    {
        moveTimeBase *= scale;
        currentMoveTime = moveTimeArray[currentMoveTimeIndex] * moveTimeBase;
    }

	// Use this for initialization
	void Start () {
        currentMoveTime = moveTimeArray[currentMoveTimeIndex] * moveTimeBase;
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
                if (GameLogicManager.Instance.player.willTeleportThis)
                {
                    GameLogicManager.Instance.player.TeleportArrived();
                }
                //achivement: keep jumping
            }
        }
	}

    public void KeepMoving(Vector3 dir,float sp = 5.0f)
    {
        target = CSMath.Vector3Inf;
        direction = dir.normalized;
        isMoving = true;
        speed = sp;
    }

    public void StopMoving()
    {
        isMoving = false;
    }
}
