using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardModeMusic : MonoBehaviour
{
    
    public AudioClip audioc;

    void Start(){
        if(PlayerStats.hardMode == true){
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = audioc;
        audio.Play();
        }
    }

}
