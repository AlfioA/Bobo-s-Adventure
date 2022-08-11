using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingChallenge : MonoBehaviour
{
    Health foxy; 
    public GameObject input;
    int i = 0;

    void Update(){
        foxy = GetComponent<Health>();
        endChallenge();
    }

    void endChallenge(){
        if(foxy.dead == true && i == 0){
            Time.timeScale = 0;
            input.SetActive(true);
            i++;
        }
    }
}
