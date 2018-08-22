using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour {
    public GameObject circlePrefab;

    public float startY = 0.0f;//y will increate
    float mapWidth = 1.0f;
    float currentGeneratedY;

    float heightScale;
    float widthScale;

    List<GameObject> generatedList;

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

    public float[] rateOfNumberOfColorOfBlockCircle = { 1, 1, 1,1 };
    float sumOfNumberOfColorOfBLockCirlcle;


    // Use this for initialization
    void Start () {
        screenWidth = Screen.width;
        screenHeight = Screen.height;

        heightScale = 9f;
        widthScale = 2.5f;


        currentGeneratedY = startY /heightScale;

        foreach (float f in rateToGenerateNumber)
        {
            sumOfGenerateNum += f;
        }
        foreach (float f in rateOfNumberOfColorOfBlockCircle)
        {
            sumOfNumberOfColorOfBLockCirlcle += f;
        }
        generatedList = new List<GameObject>();
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

        List<GameObject> thisGeneratedList = new List<GameObject>();
        if (generatedList.Count > 4)
        {
            generatedList.RemoveRange(0, generatedList.Count - 4);
        }
       for (int index = 0; index < 10; index++)
        {
            currentGeneratedY += 0.1f;
            float rateToGenerateCircle = Mathf.Pow(multiplierWhenDidntGenerateLastTime, emptyLineNumber) * originGenerateCircleRate;
            float rand = Random.Range(0, 1.0f);
            if (rand < rateToGenerateCircle)
            {
                emptyLineNumber = 0;
                //generate multiple in one line

                rand = Random.Range(0, sumOfGenerateNum);
                int generateNum = 3;
                if (rand <= rateToGenerateNumber[0])
                {
                    generateNum = 1;
                } else if (rand <= rateToGenerateNumber[0]+rateToGenerateNumber[1])
                {
                    generateNum = 2;
                }

                float randXValueLength = 1.6f * widthScale / (float)generateNum;
                float randXValueStart = -0.8f * widthScale;
                for (int num = 0; num < generateNum; num++)
                {
                      float randXValue = Random.Range(randXValueStart + randXValueLength * num, randXValueStart + randXValueLength * (num + 1));
                    Vector3 willGeneratePosition = new Vector3(randXValue, currentGeneratedY * heightScale, 0f);
                    //check collide with others
                    bool shouldSkip = false;
                    int checkNum = Mathf.Min(generatedList.Count, 4);
                    for (int cn = 1;cn<= checkNum; cn++)
                    {
                        GameObject checkObject = generatedList[generatedList.Count - cn];
                        if(Vector3.Distance(checkObject.transform.position, willGeneratePosition) <= 1.5f)
                        {
                            shouldSkip = true;
                            break;
                        }
                    }
                    if (shouldSkip)
                    {
                        continue;
                    }

                    GameObject go = CachePoolManager.Instance.getCircle();
                    go.SetActive(true);
                    go.transform.position = willGeneratePosition;
                    WholeCircle wc = go.GetComponentInChildren<WholeCircle>();
                    wc.itemObject.SetActive(false);
                    wc.ReactiveChildren();
                    wc.willChange = false;
                    Rotator rt = go.GetComponentInChildren<Rotator>();
                    generatedList.Add(go);
                    thisGeneratedList.Add(go);
                    //decide if this circle is a change circle or block circle
                    float rateToGenerateWillChangeCircle = Mathf.Pow(multiplierWHenDidntGenerateChangeCircle, noChangeCircleNumber) * originGenerateChangeCircleRate;
                    rand = Random.Range(0, 1.0f);
                    if (rand < rateToGenerateWillChangeCircle)
                    {
                        noChangeCircleNumber = 0;
                        wc.willChange = true;
                        rand = Random.Range(0, 4);
                        GameColor c1 = (GameColor)((rand + 1) % 4);
                        GameColor c2 = (GameColor)((rand + 2) % 4);
                        GameColor c3 = (GameColor)((rand + 3) % 4);
                        wc.SetColor(new GameColor[] { c1, c2, c3, (GameColor)rand });
                    }
                    else
                    {
                        noChangeCircleNumber++;
                        wc.willChange = false;

                        //random to decide what color can pass block
                        rand = Random.Range(0, sumOfNumberOfColorOfBLockCirlcle);
                        if(rand <= rateOfNumberOfColorOfBlockCircle[0])//1 color
                        {
                            rand = Random.Range(0, 4);
                            GameColor c = (GameColor)rand;
                            wc.SetColor(new GameColor[]{ c,c,c,c});
                        }
                        else if (rand <= rateOfNumberOfColorOfBlockCircle[0]+ rateOfNumberOfColorOfBlockCircle[1])//2 color
                        {
                            rand = Random.Range(0, 4);
                            GameColor c = (GameColor)rand;
                            int rand2 = Random.Range(0, 3);
                            GameColor c2 = (GameColor)((rand+rand2)%4);
                            wc.SetColor(new GameColor[] { c, c, c2,c2 });
                        }
                        else if (rand <= rateOfNumberOfColorOfBlockCircle[0] + rateOfNumberOfColorOfBlockCircle[1]+rateOfNumberOfColorOfBlockCircle[2])//1 color
                        {
                            rand = Random.Range(0, 4);
                            GameColor c1 = (GameColor)((rand + 1) % 4);
                            GameColor c2 = (GameColor)((rand + 2) % 4);
                            GameColor c3 = (GameColor)((rand + 3) % 4);
                            wc.SetColor(new GameColor[] { c1,c2,c3,c3 });
                        } else
                        {
                            rand = Random.Range(0, 4);
                            GameColor c1 = (GameColor)((rand + 1) % 4);
                            GameColor c2 = (GameColor)((rand + 2) % 4);
                            GameColor c3 = (GameColor)((rand + 3) % 4);
                            wc.SetColor(new GameColor[] { c1, c2, c3, (GameColor)rand });
                        }
                    }
                    //decide the ratate speed of the circle,randge is (-100,-50)and(50,100)
                    rand = Random.Range(-50, 50);
                    rand += (rand > 0 ? 50 : -50);
                    rt.speed = rand;
                }
            } else
            {
                emptyLineNumber++;
            }
        }
        int rand3 = Random.Range(0, thisGeneratedList.Count);
        GameObject go2 = thisGeneratedList[rand3];
        WholeCircle wc2 = go2.GetComponentInChildren<WholeCircle>();
        wc2.itemObject.SetActive(true);
        GameItemManager itemManager = wc2.itemObject.GetComponent<GameItemManager>();
        itemManager.itemEnum = (GameItemEnum)Random.Range(0, (int)GameItemEnum.random+1);
        itemManager.Init();

    }
    
}
