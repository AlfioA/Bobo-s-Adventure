using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ending : MonoBehaviour
{
    void Start(){
        PlayerStats.end=false;
    }

    public GameObject input;
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player"){
            Time.timeScale = 0;
            input.SetActive(true);
            PlayerStats.end=true;
        }
    }
}
