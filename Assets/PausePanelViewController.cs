using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PausePanelViewController : DefaultViewController
{
    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        GameLogicManager.Instance.player.isPaused = false;
        SFXController.Instance.ButtonClick();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
    
    public void Resume()
    {
        Back();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        GameLogicManager.Instance.player.isPaused = false;
        SFXController.Instance.ButtonClick();
        gameObject.SetActive(false);
        GameLogicManager.Instance.player.Restart();
    }

    public override void Back()
    {
        base.Back();
        GameLogicManager.Instance.player.isPaused = false;
        Time.timeScale = 1;
        SFXController.Instance.ButtonClick();
        gameObject.SetActive(false);
    }

}
