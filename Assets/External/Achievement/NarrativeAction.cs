using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeAction {
    public string identifier;
    public NarrativeInfo narrativeInfo;
	public NarrativeAction(NarrativeInfo info)
    {
        narrativeInfo = info;
        identifier = info.identifier;
    }
}
