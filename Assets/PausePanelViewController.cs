using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PausePanelViewController : DefaultViewController
{
    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        Player.Instance.isPaused = false;
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
        Player.Instance.isPaused = false;
        SFXController.Instance.ButtonClick();
        gameObject.SetActive(false);
        Player.Instance.Restart();
    }

    public override void Back()
    {
        base.Back();
        Player.Instance.isPaused = false;
        Time.timeScale = 1;
        SFXController.Instance.ButtonClick();
        gameObject.SetActive(false);
    }

}
