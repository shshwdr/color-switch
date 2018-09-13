using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sinbad;

public enum MonsterEnum
{
    monster,guard,assasin,
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

    public MonsterInfo GetMonsterInfoByIdentifier(string identifier)
    {
        MonsterEnum monsterEnum = (MonsterEnum)System.Enum.Parse(typeof(MonsterEnum), identifier);
        return monsterInfoList[(int)monsterEnum];
    } 

    
}
