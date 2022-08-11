using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptToLoad : MonoBehaviour
{
    public void Loading(){
        MoneyAndTimerSaving.GetSaving();
        MoneyAndTimerSaving.GetTimer();
    }

    public void Saving(){
        MoneyAndTimerSaving.SetSaving();
        MoneyAndTimerSaving.SaveTimer();
    }

    public void NewGaming(){
        MoneyAndTimerSaving.InitializeCoins();
    }
}
