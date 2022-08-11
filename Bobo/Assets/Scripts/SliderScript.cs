using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Threading.Tasks;

public class SliderScript : MonoBehaviour
{
    [SerializeField]int typeofSlider;
    float value;
    public Slider volumeSlider;
    public AudioMixer mixer;

    void Start()
    {
        if(typeofSlider==1){  
            volumeSlider.value=PlayerPrefs.GetFloat("save", value);
            if(volumeSlider.value==0){
                volumeSlider.value=1;
            }
        }
        else{
            volumeSlider.value=PlayerPrefs.GetFloat("save2", value);
            if(volumeSlider.value==0){
                volumeSlider.value=0.5f;
            }
        }
    }

    public void SetLevel(float sliderValue){
        value=sliderValue;
        mixer.SetFloat("MusicVol",Mathf.Log10(sliderValue)*20);
        if(typeofSlider==1){  
            PlayerPrefs.SetFloat("save",value);
        }
        else{
            PlayerPrefs.SetFloat("save2",value);
        }
    }
}
