using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverViewController : PausePanelViewController
{

    public override void Back()
    {
        base.Back();
        Restart();
    }
}
