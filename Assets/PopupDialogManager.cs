using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupDialogManager : Singleton<PopupDialogManager> {
    public GameObject dialogPrefab;
    public Transform canvasTransform;
    public void CreatePopupDialog(string t, string m)
    {
        GameObject go = Instantiate(dialogPrefab, canvasTransform);
        PopupDialog script = go.GetComponent<PopupDialog>();
        script.Setup(t, m);
    }
}
