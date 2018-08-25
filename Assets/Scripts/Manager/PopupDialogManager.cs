using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public delegate void DialogDelegate();
public class PopupDialogManager : Singleton<PopupDialogManager> {
    public GameObject dialogPrefab;
    public Transform canvasTransform;


    public PopupDialog CreatePopupDialog(string t, string m)
    {
        return CreatePopupDialog(t, m, false,null,null,null);
    }

    public PopupDialog CreatePopupDialog(string t, string m, DialogDelegate okDelegate)
    {
        return CreatePopupDialog(t, m, false, null, null,okDelegate);
    }

    public PopupDialog CreatePopupDialog(string t, string m, bool hasYesAndNo, DialogDelegate yesDelegate, DialogDelegate noDelegate)
    {
        return CreatePopupDialog(t, m, hasYesAndNo, yesDelegate, noDelegate, null);
    }
    public PopupDialog CreatePopupDialog(string t, string m, bool hasYesAndNo, DialogDelegate yesDelegate, DialogDelegate noDelegate,DialogDelegate okDelegate)
    {
        GameObject go = Instantiate(dialogPrefab, canvasTransform);
        PopupDialog script = go.GetComponent<PopupDialog>();
        script.Setup(t, m,hasYesAndNo,yesDelegate,noDelegate, okDelegate);
        return script;
    }

    public PopupDialog CreatePopupDialog(string t, string m,DialogDelegate okDelegate,  TextAlignmentOptions alignment,bool darkenBackground)
    {
        PopupDialog script = CreatePopupDialog(t, m, okDelegate);
        script.ChangeMessageAllignment(alignment);
        if (darkenBackground)
        {
            script.DarkenBackground();
        }
        return script;
    }
}
