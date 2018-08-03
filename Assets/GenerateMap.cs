using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour {
    public GameObject circlePrefab;

    float startY = 0.0f;//y will increate
    float mapWidth = 1.0f;
    float currentGeneratedY;

    float heightScale;
    float widthScale;

    float generateStepY = 0.1f;

    float screenWidth;
    float screenHeight;

    public float originGenerateCircleRate = 0.1f;
    public float multiplierWhenDidntGenerateLastTime = 2;
    public float[] rateToGenerateNumber = { 3, 2, 1 };
    float sumOfGenerateNum;
    int emptyLineNumber = 0;

    public float originGenerateChangeCircleRate = 0.1f;
    public float multiplierWHenDidntGenerateChangeCircle = 1.8f;
    int noChangeCircleNumber = 0;
    

	// Use this for initialization
	void Start () {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        currentGeneratedY = startY;

        heightScale = 9f;
        widthScale = 3f;

        foreach(float f in rateToGenerateNumber)
        {
            sumOfGenerateNum += f;
        }
    }
	
	// Update is called once per frame
	void Update () {
		if(Player.Instance.transform.position.y > (currentGeneratedY-1)* heightScale)
        {
            GenerateScreen(0);
        }
	}

    void GenerateScreen(int hardness)
    {
       for (int i = 0; i < 10; i++)
        {
            currentGeneratedY += 0.1f;
            float rateToGenerateCircle = Mathf.Pow(multiplierWhenDidntGenerateLastTime, emptyLineNumber) * originGenerateCircleRate;
            float rand = Random.Range(0, 1.0f);
            if (rand < rateToGenerateCircle)
            {
                emptyLineNumber = 0;
                //generate multiple in one line
                //rand = Random.Range(0,sum)
                float randXValue = Random.Range(-0.8f * widthScale, 0.8f * widthScale);
                //check collide with others
                GameObject go = Instantiate(circlePrefab, new Vector3(randXValue, currentGeneratedY * heightScale, 0f),Quaternion.identity);
                WholeCircle wc = go.GetComponent<WholeCircle>();
                Rotator rt = go.GetComponent<Rotator>();

                //decide if this circle is a change circle or block circle
                float rateToGenerateWillChangeCircle = Mathf.Pow(multiplierWHenDidntGenerateChangeCircle, noChangeCircleNumber) * originGenerateChangeCircleRate;
                rand = Random.Range(0, 1.0f);
                if (rand < rateToGenerateWillChangeCircle)
                {
                    noChangeCircleNumber = 0;
                    wc.willChange = true;
                }
                else
                {
                    noChangeCircleNumber++;
                    wc.willChange = false;
                }

                //decide the ratate speed of the circle,randge is (-100,-50)and(50,100)
                rand = Random.Range(-50, 50);
                rand += (rand > 0 ? 50 : -50);
                rt.speed = rand;
            } else
            {
                emptyLineNumber++;
            }
        }
    }
    
}
