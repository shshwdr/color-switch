using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sinbad;


public class LevelManager : Singleton<LevelManager> {
    public int currentLevel = 0;
    public List<LevelInfo> levelInfoList;
    public LevelInfo currentLevelInfo { get { return levelInfoList[currentLevel]; } }
    public void Init() {
        ReadCSV();
    }
    private void Start()
    {
    }
    void ReadCSV()
    {
        levelInfoList = CsvUtil.LoadObjects<LevelInfo>("level.csv");

    }

    public string GenerateAMonsterIdentifier()
    {
        Dictionary<string,string> probability = currentLevelInfo.monstersWithProbability;
        int sum = 0;
        List<string> keys = new List<string>();
        List<int> values = new List<int>();
        foreach(string key in probability.Keys)
        {
            int value  = int.Parse(probability[key]);
            keys.Add(key);
            values.Add(value);
            sum += value;
        }
        int rand = Random.Range(0, sum);
        int tempSum = 0;
        for(int i = 0;i<values.Count;i++)
        {
            int value = values[i];
            tempSum += value;
            if (rand <= tempSum)
            {
                return keys[i];
            }
        }
        Debug.LogError("rand " + rand+" values: "+values+" keys: "+keys);
        return keys[0];
    }

    
}
