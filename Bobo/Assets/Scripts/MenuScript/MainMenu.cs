using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    int value;
    ScriptToLoad loading;

    public void Start(){
        loading=new ScriptToLoad();
        Time.timeScale=1;
    }
    public void PlayGame(){
        PlayerStats.health=3;
        MoneyAndTimerSaving.InitializeCoins();
        PlayerStats.damage = 1;
        PlayerStats.purpleShot=false;
        PlayerStats.dead=false;
        PlayerStats.money=0;
        PlayerStats.score=0;
        PlayerStats.key=0;
        PlayerStats.checkpoint=0;
        PlayerStats.hardMode=false;
        TextController.timer=300;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ThisLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {   
        PlayerStats.end = false;
        PlayerStats.challengeMode=false;
        PlayerStats.hardMode = false;
        PlayerStats.dead=false;
        //PlayerPrefs.SetInt("checkpoint", PlayerStats.checkpoint);
        loading.Loading();
        SceneManager.LoadScene(0);
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene(3);
    }
    public void QuitGame(){
        Application.Quit();
    }

    public void LoadGame(){
        if(!PlayerStats.hardMode){
            PlayerStats.damage = 1;
            PlayerStats.purpleShot=false;
            PlayerStats.key=0;
            loading.Loading();
            SceneManager.LoadScene(1);
        }
        else{
            HardMode();
        }      
    }

    public void LoadChallengeMode(){
        PlayerStats.health = 3;
        PlayerStats.damage = 1;
        PlayerStats.purpleShot=false;
        PlayerStats.score = 0;
        PlayerStats.money = 0;
        PlayerStats.challengeMode=true;
        TextController.timer=300;
        SceneManager.LoadScene(2);
    }

    public void HardMode(){
        PlayerStats.hardMode=true;
        PlayerStats.health=3;
        MoneyAndTimerSaving.InitializeCoins();
        PlayerStats.damage = 1;
        PlayerStats.purpleShot=false;
        PlayerStats.dead=false;
        PlayerStats.money=0;
        PlayerStats.score=0;
        PlayerStats.key=0;
        PlayerStats.checkpoint=0;
        TextController.timer=300;
        SceneManager.LoadScene(1);
    }

    public void Retry(){
        
        if(PlayerStats.hardMode == true){
            PlayerStats.challengeMode=false;
            PlayerStats.dead=false;
            SceneManager.LoadScene(0);
            //PlayerPrefs.SetInt("checkpoint", PlayerStats.checkpoint);
        }
        else{
            PlayerStats.challengeMode=false;
            PlayerStats.hardMode = false;
            PlayerStats.dead=false;
            //PlayerPrefs.SetInt("checkpoint", PlayerStats.checkpoint);
            loading.Loading();
            SceneManager.LoadScene(0);
        }
    }

}
