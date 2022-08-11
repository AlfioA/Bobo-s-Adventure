using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI_InputWindow : MonoBehaviour
{

    private Button okBtn;
    private Button cancelBtn;
    private TMP_InputField input;
    public GameObject highscoreTable;
    private void Awake(){
        okBtn=transform.Find("ButtonOk").GetComponent<Button>();
        //cancelBtn=transform.Find("CancelButton").GetComponent<Button>();
        input=transform.Find("InputField").GetComponent<TMP_InputField>();
        Hide();
        Show();
    }
    public void Show(){
        gameObject.SetActive(true);
        input.text="";
    }

    public void Store(){
        PlayerStats.name=input.text;
        CheckAndCut();
        Hide();
        highscoreTable.SetActive(true);
    }

    public void Cancel(){
        input.text="";
    }

    public void Hide(){
        gameObject.SetActive(false);
    }

    void CheckAndCut(){
        if(PlayerStats.money>=45){
            PlayerStats.score+=500;
        }
        if(PlayerStats.hardMode){
            PlayerStats.score+=100;
        }
        if(PlayerStats.name.Length>7){
            PlayerStats.name=PlayerStats.name.Substring(0,7);
        }
    }

}
