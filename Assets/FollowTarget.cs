using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {
    public float scrollSpeed = 0.1f;
    public float[] speedArray = { 0.05f, 0.07f, 0.1f, 0.15f, 0.2f };
    int currentSpeedIndex = 2;

    float shakePower;
    float shakeDuration;

	// Use this for initialization
	void Start () {
        originPosition = transform.position;

    }

    public void Speedup()
    {
        currentSpeedIndex =  Mathf.Min(currentSpeedIndex + 1, speedArray.Length - 1);
        scrollSpeed = speedArray[currentSpeedIndex];
    }

    public void Slowdown()
    {
        currentSpeedIndex = Mathf.Max(currentSpeedIndex - 1, 0);
        scrollSpeed = speedArray[currentSpeedIndex];
    }

    Vector3 originPosition;

    // Update is called once per frame
    void Update () {
        Vector2 shakePos = Vector2.zero;
        if (shakeDuration > 0)
        {
            shakeDuration -= Time.deltaTime;
            shakePos = Random.insideUnitCircle * shakePower;

        }
        Vector3 playerPosition = Player.Instance.transform.position;
        if (Player.Instance.isGameOver)
        {
            transform.position = new Vector3(originPosition.x, playerPosition.y, originPosition.z);
        }
        else
        {
            if (Player.Instance.gameStarted)
            {
                originPosition = new Vector3(originPosition.x, originPosition.y + scrollSpeed * Time.deltaTime, originPosition.z);
            }
            if (playerPosition.y > transform.position.y)
            {
                originPosition = new Vector3(originPosition.x, playerPosition.y, originPosition.z);
            }
        }

        transform.position = originPosition + new Vector3(shakePos.x, shakePos.y, 0);
	}

    public void ShakeCamera(float shakeDur = 0.3f,float shakePwr= 0.15f)
    {
        shakePower = shakePwr;
        shakeDuration = shakeDur;
    }
}
