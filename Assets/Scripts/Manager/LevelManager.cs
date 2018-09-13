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
        foreach(string key in probability.Keys)
        {
            return key;
        }
        Debug.LogError("probability does not have keys for level " + currentLevelInfo.identifier);
        return "";
    }

    
}
