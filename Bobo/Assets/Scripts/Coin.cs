using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int id;
    void Start()
    {
        if(MoneyAndTimerSaving.Coins[id]==0){
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag=="Player"){
            MoneyAndTimerSaving.Coins[id]=0;
        }
    }
}
