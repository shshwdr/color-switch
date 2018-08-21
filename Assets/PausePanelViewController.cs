using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PausePanelViewController : DefaultViewController
{
    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        SFXController.Instance.ButtonClick();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
    
    public void Resume()
    {
        Time.timeScale = 1;
        SFXController.Instance.ButtonClick();
        gameObject.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SFXController.Instance.ButtonClick();
        gameObject.SetActive(false);
        Player.Instance.Restart();
    }

    public override void Back()
    {
        base.Back();
        Resume();
    }

}
