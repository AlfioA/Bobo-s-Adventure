using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MoneyAndTimerSaving
{
    public static int[] Coins=new int[45];
    public static int timer=300;


    public static void InitializeCoins(){
        for(int i=0;i<Coins.Length;i++){
            Coins[i]=1;
        }
    }
    public static void GetSaving(){
        InitializeCoins();//nel caso non ci siano salvataggi restano i valori di default
        for (int i = 0; i < Coins.Length; i++){
            Coins[i]=PlayerPrefs.GetInt("Coins"+ i,Coins[i]);
        }
    }

    public static void SetSaving(){
        for (int i = 0; i < Coins.Length; i++){
            PlayerPrefs.SetInt("Coins"+ i,Coins[i]);
        }
    }

    public static void GetTimer(){
        PlayerStats.health=PlayerPrefs.GetInt("health",PlayerStats.health);
        Debug.Log(PlayerStats.health);
        PlayerStats.checkpoint=PlayerPrefs.GetInt("checkpoint",PlayerStats.checkpoint);
        PlayerStats.score=PlayerStats.score=PlayerPrefs.GetInt("Scoring",PlayerStats.score);
        PlayerStats.money=PlayerPrefs.GetInt("money",PlayerStats.money);
        TextController.timer=PlayerPrefs.GetFloat("Timer",TextController.timer);
    }

    public static void SaveTimer(){
        PlayerPrefs.SetInt("health",PlayerStats.health);
        PlayerPrefs.SetInt("Scoring",PlayerStats.score);
        PlayerPrefs.SetInt("money",PlayerStats.money);
        PlayerPrefs.SetFloat("Timer",TextController.timer);
        PlayerPrefs.SetInt("checkpoint",PlayerStats.checkpoint);
    }

    public static void ResetTimer(){
        timer=300;
    }
}

