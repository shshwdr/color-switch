using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameViewController : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject helpPanel;

    public GameObject itemHelpCell;
    public GameObject itemHelpPanel;
    // Use this for initialization
    void Start()
    {
        InitHelpView();
    }

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

    public void InitHelpView()
    {
        foreach(ItemInfo info in GameItem.Instance.itemInfoList)
        {
            GameObject go = Instantiate(itemHelpCell);
            go.transform.parent = itemHelpPanel.transform;
            Image image = go.GetComponentsInChildren<Image>()[1];
            TextMeshProUGUI text = go.GetComponentInChildren<TextMeshProUGUI>();
            image.sprite = info.icon;
            text.text = info.description;
        }
    }

}
