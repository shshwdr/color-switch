using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PausePanelViewController : DefaultViewController
{
    public void BackToMainMenu()
    {
        GameLogicManager.Instance.Resume();
        SFXController.Instance.ButtonClick();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
    
    public void Resume()
    {
        Back();
    }

    public void Restart()
    {
        GameLogicManager.Instance.Resume();
        SFXController.Instance.ButtonClick();
        gameObject.SetActive(false);
        GameLogicManager.Instance.player.Restart();
    }

    public override void Back()
    {
        base.Back();
        GameLogicManager.Instance.Resume();
        SFXController.Instance.ButtonClick();
        gameObject.SetActive(false);
    }

}
