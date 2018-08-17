using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sinbad;

public enum AbilityEnum {
    normal,
fireBall,
lightningBall,
waterBall,
thiefBall,
lifeBall,
goldBall,
strongBall,
loveBall,
}

public class AbilityManager : Singleton<AbilityManager>
{
    public List<AbilityInfo> abilityInfoList;
    public Dictionary<string, PersistentBall> ballsOwned;


    string currentlyUsingBall;

    private void Start()
    {
        ReadCSV();
        ReadDatabase();
    }
    void ReadCSV()
    {
        abilityInfoList = CsvUtil.LoadObjects<AbilityInfo>("ability.csv");
    }

    void ReadDatabase()
    {
        ballsOwned = new Dictionary<string, PersistentBall>();
       DataService ds =   SQLiteDatabaseManager.Instance.ds;
        IEnumerable<PersistentBall> balls = ds.GetBallsOwned();
        foreach (PersistentBall ball in balls)
        {
            ballsOwned[ball.identifier] = ball;
            if (ball.isUsing)
            {
                currentlyUsingBall = ball.identifier;
            }
        }
    }

    public bool isBallOwned(string identifier)
    {
        return ballsOwned.ContainsKey(identifier);
    }

    public bool isBallInUse(string identifier)
    {
        return isBallOwned(identifier) && ballsOwned[identifier].isUsing;
    }

    public void unlockBallOwned(string identifier)
    {
        DataService ds = SQLiteDatabaseManager.Instance.ds;
        PersistentBall ball = new PersistentBall();
        ball.identifier = identifier;
        ball.isUsing = false;
        ds.InsertBall(ball);
        ballsOwned[identifier] = ball;
    }

    public string useBall(string identifier, bool use = true)
    {
        string res = currentlyUsingBall;
        if (currentlyUsingBall!=null)
        {
            p_useBall(currentlyUsingBall,false);
        }
        else
        {
            Debug.LogError("no currently use ball");
        }

        p_useBall(identifier);
        currentlyUsingBall = identifier;
        return res;
    }

    void p_useBall(string identifier, bool use = true)
    {
        DataService ds = SQLiteDatabaseManager.Instance.ds;
        PersistentBall ball = ds.GetBall(identifier);
        ball.isUsing = use;
        ds.UpdateBall(ball);
        ballsOwned[identifier].isUsing = use;
    }
}
