using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using System;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;

public class GooglePlayManager : MonoBehaviour {

    private static GooglePlayManager THE_INSTANCE;

    public GooglePlayManager()
    {
        THE_INSTANCE = this;

    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
       
    }

    public void Init(Action<bool> callback)
    {
        //init google play
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        //enable debugging output
        PlayGamesPlatform.DebugLogEnabled = true;
        //initialize and activate platform
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        //try silent sign in
        PlayGamesPlatform.Instance.Authenticate(callback, true);
    }

    public bool isAutenticated()
    {
        return PlayGamesPlatform.Instance.localUser.authenticated;
    }

    public static GooglePlayManager Instance
    {
        get
        {
            return THE_INSTANCE;
        }
    }


    public void SignIn(Action<bool> callback)
    {
        //CSUtil.LOG("signin called in googleplayManager");
        if (!PlayGamesPlatform.Instance.localUser.authenticated)
        {
            //CSUtil.LOG("start authenticate");
            PlayGamesPlatform.Instance.Authenticate(callback, false);
        }
        else
        {
            PlayGamesPlatform.Instance.SignOut();
            callback(true);
            //signinButtonText.text = "Sign in";
            //authStatus.text = "";
        }
    }


    public void ShowAchievements()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowAchievementsUI();
        }
        else
        {
            //CSUtil.LOG("can't show achievement, not logged in");
        }
    }

    public void ShowLeaderboard()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI();
        }
        else
        {
            //CSUtil.LOG("can't show leaderboard");
        }
    }
}
