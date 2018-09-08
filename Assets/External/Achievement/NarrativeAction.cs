using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeAction {
    public string identifier;
    public NarrativeInfo narrativeInfo;
    bool isEnabled;
	public NarrativeAction(NarrativeInfo info)
    {
        narrativeInfo = info;
        identifier = info.identifier;
    }

    public virtual void Enable()
    {
        if (!isEnabled)
        {
            isEnabled = true;
            P_Enable();
        }
    }

    protected virtual void P_Enable()
    {

    }

    public virtual void Disable()
    {
        isEnabled = false;
    }

    public virtual void Finish()
    {
        Disable();
    }
}
