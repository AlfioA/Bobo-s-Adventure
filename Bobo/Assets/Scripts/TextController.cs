using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextController : MonoBehaviour
{
    public Text coinText;
    public Text scoreText;
    public Text waveText;
    public TMP_Text timerText;
    public static float timer;
    public static int number=300;

    // Start is called before the first frame update
    void Start()
    {   
        if(PlayerStats.hardMode){
            timer = 300;
        }
        //text = GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if(!PlayerStats.challengeMode){
            changeTimer();
        }
        timer-=Time.deltaTime;
        if(!PlayerStats.challengeMode){
            coinText.text = PlayerStats.money.ToString()+"/45";
        }
        else{
            coinText.text=PlayerStats.money.ToString();
        }
        scoreText.text = PlayerStats.score.ToString();
        if(waveText!=null){
            waveText.text = PlayerStats.wave.ToString();
        }
    }

    void changeTimer(){
        number = (int)timer;
        MoneyAndTimerSaving.timer=number;
        timerText.text=number.ToString();
        if(number <= 0){
            PlayerStats.dead = true;
        }
        
    }
}
