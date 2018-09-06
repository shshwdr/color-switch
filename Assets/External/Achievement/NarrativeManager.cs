using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sinbad;

public class NarrativeManager : Singleton<NarrativeManager> {
    Dictionary<string, HashSet<NarrativeAction>> narrativeActionDictionary;
    List<NarrativeAction> activeNarrativeActions;
    public void Init() {
        List<NarrativeInfo> narrativeInfoList = CsvUtil.LoadObjects<NarrativeInfo>("narrative.csv");
        narrativeActionDictionary = new Dictionary<string, HashSet<NarrativeAction>>();
        activeNarrativeActions = new List<NarrativeAction>();
        foreach(NarrativeInfo info in narrativeInfoList)
        {
            System.Type narrativeType = System.Type.GetType(info.narrativeAction);
            NarrativeAction action = (NarrativeAction)System.Activator.CreateInstance(narrativeType, info);
            if (!narrativeActionDictionary.ContainsKey(info.achievement))
            {
                narrativeActionDictionary[info.achievement] = new HashSet<NarrativeAction>();
            }
            narrativeActionDictionary[info.achievement].Add(action);
        }
    }

    public void UpdateAchievement(string achievement, AchievementState oldState,AchievementState newState)
    {
        if(oldState == AchievementState.locked && newState == AchievementState.active)
        {

            Debug.LogError("update " + achievement + " " + oldState + " " + newState);
            activeNarrativeActions.AddRange(narrativeActionDictionary[achievement]);
        }
    }

    private void Update()
    {
        foreach(NarrativeAction action in activeNarrativeActions)
        {
            Debug.LogError("action " + action.identifier);
        }
    }
}
