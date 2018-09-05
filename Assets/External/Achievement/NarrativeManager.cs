using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sinbad;

public class NarrativeManager : Singleton<NarrativeManager> {

    public void Init() {
        List<NarrativeInfo> achievementInfoList = CsvUtil.LoadObjects<NarrativeInfo>("narrative.csv");
    }

}
