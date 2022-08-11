using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{    
    public GameObject dMenu;
    public GameObject Sound;
    void Start(){
        dMenu.SetActive(false);
        Sound.SetActive(true);    
    }
    void Update(){
        if(PlayerStats.dead){
            Sound.SetActive(false);
            dMenu.SetActive(true);
            Time.timeScale = 0f;
            SoundManagerScript.Instance.PlaySound("death");
            PlayerStats.dead=false;
        }
    }
}

