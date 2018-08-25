using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class SQLiteDatabaseManager : Singleton<SQLiteDatabaseManager> {
    private string conn, sqlQuery;
    IDbConnection dbconn;
    IDbCommand dbcmd;
    public DataService ds;
    // Use this for initialization

    public void Init()
    {
        ds = new DataService("db.s3db");
        var currency = ds.GetPersistentCurrencys();
    }
    void Start()
    {
        
    }


    public void Updatevalue( string id, int amount)
    {
        PersistentCurrency currency = ds.GetGoldAmount();
        currency.amount = amount;
        ds.UpdateGoldAmount(currency);
    }
    


    public int AmountOfCurrency(string currencyId)
    {
        return ds.GetGoldAmount().amount;
    }
}
