using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuViewController : DefaultViewController
{

    TextMeshProUGUI signInButtonText;
    TextMeshProUGUI authStatus;
    GameObject leaderboardButton;
    GameObject achievementButton;

    // Use this for initialization
    void Start()
    {
        signInButtonText = GameObject.Find("SignInButton").GetComponentInChildren<TextMeshProUGUI>();
        leaderboardButton = GameObject.Find("LeaderBoardButton");
        achievementButton = GameObject.Find("AchievementButton");
        authStatus = GameObject.Find("authStatusText").GetComponent<TextMeshProUGUI>();
        UpdateGooglePlayButtons(false);
        GooglePlayManager.Instance.Init(SignInCallback);
        if (GooglePlayManager.Instance.isAutenticated())
        {
            UpdateGooglePlayButtons(true);
        }
    }

    public void SignInCallback(bool success)
    {
        if (success)
        {
            //CSUtil.LOG("signed in");
            signInButtonText.text = "Sign out";
            authStatus.text = "";
            //authStatus.text = "Signed in as " + Social.localUser.userName;
            UpdateGooglePlayButtons(true);
        }
        else
        {
            //CSUtil.LOG("sign in failed");
            signInButtonText.text = "Sign in";
            authStatus.text = "Signed in failed";
            UpdateGooglePlayButtons(false);
        }
    }

    void UpdateGooglePlayButtons(bool isTurnedOn)
    {
        leaderboardButton.SetActive(isTurnedOn);
        achievementButton.SetActive(isTurnedOn);
    }

    public void SignOutCallback(bool success)
    {
        if (success)
        {
            //CSUtil.LOG("sign out succeed");
            signInButtonText.text = "Sign in";
            authStatus.text = "Signed out";
            UpdateGooglePlayButtons(false);
        }
        else
        {
            //CSUtil.LOG("why would sign out failed???");
        }
    }

    public void PlayGame()
    {
        //CSUtil.LOG("play button clicked");
        SceneManager.LoadScene("Game");
    }

    public void SignIn()
    {
        //CSUtil.LOG("signin button clicked");
        if (!GooglePlayManager.Instance.isAutenticated())
        {
            GooglePlayManager.Instance.SignIn(SignInCallback);
        }
        else
        {
            GooglePlayManager.Instance.SignIn(SignOutCallback);
        }
    }

    public override void Back()
    {
        base.Back();
        DialogDelegate yesDelegate = QuitGame;
        DialogDelegate noDelegate = delegate { gameObject.SetActive(true); };
        PopupDialogManager.Instance.CreatePopupDialog("QUIT GAME", "Are you sure you want to quit this game? Q-Q", true, yesDelegate, noDelegate);
    }

    void QuitGame()
    {
        //Debug.LogError("quit game");
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
