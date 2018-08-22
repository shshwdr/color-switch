using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void DialogDelegate();
public class PopupDialogManager : Singleton<PopupDialogManager> {
    public GameObject dialogPrefab;
    public Transform canvasTransform;


    public void CreatePopupDialog(string t, string m)
    {
        CreatePopupDialog(t, m, false,null,null);
    }

    public void CreatePopupDialog(string t, string m, bool hasYesAndNo, DialogDelegate yesDelegate, DialogDelegate noDelegate)
    {
        GameObject go = Instantiate(dialogPrefab, canvasTransform);
        PopupDialog script = go.GetComponent<PopupDialog>();
        script.Setup(t, m,hasYesAndNo,yesDelegate,noDelegate);
    }
}
