﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : Singleton<CurrencyManager> {
    int goldValue = 0;

    public void Init()
    {
        goldValue = SQLiteDatabaseManager.Instance.AmountOfCurrency(CSConstant.GOLD);
    }
    public void Start()
    {
        
    }

    public void AddCurrencyAmount(string currencyIdentifier, int addValue)
    {
        goldValue += addValue;
        SQLiteDatabaseManager.Instance.Updatevalue(CSConstant.GOLD, goldValue);
    }

    public int GetCurrencyAount(string currencyIdentifier)
    {
        return goldValue;
    }
}
