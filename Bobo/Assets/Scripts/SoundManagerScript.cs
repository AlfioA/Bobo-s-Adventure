using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManagerScript : MonoBehaviour //Singleton
{
    float value;
    public static AudioClip shoot;
    public static AudioClip coin;

    public static AudioClip death;
    static AudioSource audioSrc;

    public static SoundManagerScript _instance; 

    //SoundManagerScript soundmanager=SoundManagerScript.Instance; in altre classi
    public static SoundManagerScript Instance { get => _instance; }

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        shoot = Resources.Load<AudioClip>("shootSFX");
        coin = Resources.Load<AudioClip>("CoinTouch");
        death =Resources.Load<AudioClip>("GameOver");

        audioSrc = GetComponent<AudioSource>();
    }

    public void PlaySound(string clip){

        switch(clip){
            case "shoot":
            audioSrc.PlayOneShot(shoot);
            break;
            case "coin":
            audioSrc.PlayOneShot(coin);
            break;
            case "death":
            audioSrc.PlayOneShot(death);
            break;
        }
    }

    public AudioSource GetAudioSource(){
        return audioSrc;
    }
}
