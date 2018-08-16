using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sinbad;

public class AbilityManager : Singleton<AbilityManager>
{
    public List<AbilityInfo> abilityInfoList;

    private void Start()
    {
        ReadCSV();
    }
    void ReadCSV()
    {
        abilityInfoList = CsvUtil.LoadObjects<AbilityInfo>("ability.csv");
    }
}
