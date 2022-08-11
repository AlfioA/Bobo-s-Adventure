using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{   
    
    int health;
    int key;
    int score;
    public PlayerData(){
        health=PlayerStats.health;
        key=PlayerStats.key;
        score=PlayerStats.score;
    }
}
