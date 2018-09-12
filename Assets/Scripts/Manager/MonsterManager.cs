using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sinbad;

public enum MonsterEnum
{
    monster,assasin,
};

public class MonsterManager : Singleton<MonsterManager> {

    public List<MonsterInfo> monsterInfoList;
    public void Init() {
        ReadCSV();
    }
    private void Start()
    {
    }
    void ReadCSV()
    {
        monsterInfoList = CsvUtil.LoadObjects<MonsterInfo>("monster.csv");

    }

    
}
