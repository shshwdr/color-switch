using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sinbad;

public class NarrativeManager : Singleton<NarrativeManager> {
    Dictionary<string, HashSet<NarrativeAction>> narrativeActionDictionary;
    List<NarrativeAction> activeNarrativeActions;
    HashSet<string> enabledNarrativeActions;
    public void Init() {
        List<NarrativeInfo> narrativeInfoList = CsvUtil.LoadObjects<NarrativeInfo>("narrative.csv");
        narrativeActionDictionary = new Dictionary<string, HashSet<NarrativeAction>>();
        enabledNarrativeActions = new HashSet<string>();
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
        if (narrativeActionDictionary == null)
        {
            return;
        }
        if(oldState == AchievementState.locked && newState == AchievementState.active)
        {

            Debug.Log("update " + achievement + " " + oldState + " " + newState);
            if (narrativeActionDictionary.ContainsKey(achievement)) { 
                activeNarrativeActions.AddRange(narrativeActionDictionary[achievement]);
            }
        }
        //sort
    }

    private void Update()
    {
        if (narrativeActionDictionary == null)
        {
            return;
        }
        foreach (NarrativeAction action in activeNarrativeActions)
        {
            if (!enabledNarrativeActions.Contains(action.identifier))
            {
                action.Enable();
                enabledNarrativeActions.Add(action.identifier);
            }
        }
    }
}
