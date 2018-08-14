using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameViewController : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject helpPanel;


    // Use this for initialization
    

    // Update is called once per frame
    void Update()
    {

    }

    public void BackToMainMenu()
    {
        //CSUtil.LOG("back to main menu button clicked");
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }

    public void Pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        Player.Instance.Restart();
    }



}
