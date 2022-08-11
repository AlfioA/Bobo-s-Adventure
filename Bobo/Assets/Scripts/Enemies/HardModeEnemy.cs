using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardModeEnemy : MonoBehaviour
{
    void Start(){
        if(PlayerStats.hardMode==false){
            gameObject.SetActive(false);
        }
    }
}
