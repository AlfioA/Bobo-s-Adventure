using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class HighscoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;
    int level;

    private void Awake(){
        //FirstInitialize(); 
        //Delete();
        level = SceneManager.GetActiveScene().buildIndex;
    }

    private void ShowTable(){
        //FirstInitialize();
        //Delete();
        entryContainer=transform.Find("highscoreEntryContainer");
        entryTemplate=entryContainer.Find("highscoreEntryTemplate");
        entryTemplate.gameObject.SetActive(false);


        string jsonString=PlayerPrefs.GetString("highscoreTable" + level);
        Highscores highscores=JsonUtility.FromJson<Highscores>(jsonString);

        //selection Sort 
        for(int i=0;i<highscores.highscoreEntryList.Count;i++){
            for(int j=i+1;j<highscores.highscoreEntryList.Count;j++){
                if(highscores.highscoreEntryList[j].score>highscores.highscoreEntryList[i].score){
                    HighscoreEntry tmp=highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i]=highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j]=tmp;
                }
            }
        }

        highscoreEntryTransformList=new List<Transform>();

        foreach(HighscoreEntry highscoreEntry in highscores.highscoreEntryList){
            CreateHighscoreEntryTransform(highscoreEntry,entryContainer,highscoreEntryTransformList);
        }
    }

    //to show the scoretable graphically
    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry,Transform container,List<Transform> transformList){
        float templateHeight=70f;
        Transform entryTransform=Instantiate(entryTemplate,container);
        RectTransform entryRectTransform=entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition=new Vector2(0,(-templateHeight*transformList.Count)-150);
        entryTransform.gameObject.SetActive(true);

        int rank=transformList.Count+1;
        string rankString;
        switch(rank){
            default:
                rankString=rank+"TH";break;
            case 1: rankString="1ST";break;
            case 2: rankString="2ND";break;
            case 3: rankString="3RD";break;
        }
        entryTransform.Find("posText").GetComponent<TextMeshProUGUI>().text=rankString;

        int score=highscoreEntry.score;//per adesso
        entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().text=score.ToString();

        string name=highscoreEntry.name;//per adesso
        entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().text=name;

        //Set background visible odds and evens
        entryTransform.Find("background").gameObject.SetActive(rank%2==1);

        if(rank==1){//colore dorato
            entryTransform.Find("posText").GetComponent<TextMeshProUGUI>().color=Color.yellow;
            entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().color=Color.yellow;
            entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().color=Color.yellow;
        }
        else if(rank==2){
            entryTransform.Find("posText").GetComponent<TextMeshProUGUI>().color=Color.cyan;
            entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().color=Color.cyan;
            entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().color=Color.cyan;
        }
        else if(rank==3){
            entryTransform.Find("posText").GetComponent<TextMeshProUGUI>().color=Color.red;
            entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().color=Color.red;
            entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().color=Color.red;
        }
        transformList.Add(entryTransform);
    }

    public void AddHighscoreEntry(){
        //Create HighscoreEntry
        HighscoreEntry highscoreEntry=new HighscoreEntry{score=PlayerStats.score,name=PlayerStats.name};

        //Load Saved Highscores
        string jsonString=PlayerPrefs.GetString("highscoreTable" + level);
        Highscores highscores=JsonUtility.FromJson<Highscores>(jsonString);
        if(highscores == null){
            highscores=new Highscores{highscoreEntryList=new List<HighscoreEntry>()};
        }

        //Add new entry to Highscores but only if there are less than five elements
        if(highscores.highscoreEntryList.Count<5){
            highscores.highscoreEntryList.Add(highscoreEntry);
        }
        else if(PlayerStats.score>highscores.highscoreEntryList.Last().score){//substitude
            int i=0;//i-esima posizione
            foreach(HighscoreEntry highscoreEntri in highscores.highscoreEntryList){
                if(PlayerStats.score>highscoreEntri.score){
                    highscores.highscoreEntryList.RemoveAt(4);
                    highscores.highscoreEntryList.Insert(i,highscoreEntry);
                    break;
                }
                i++;
            }
        }
        //else substitude values if necessary

        //Save updated Highscores
        string json=JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable" + level,json);
        PlayerPrefs.Save();
        highscoreEntryTransformList=new List<Transform>();

        ShowTable();
    }

    public void FirstInitialize(){
        Highscores highscores=new Highscores{highscoreEntryList=new List<HighscoreEntry>()};
        string json=JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable" + 1,json);
        PlayerPrefs.SetString("highscoreTable" + 2,json);
        PlayerPrefs.Save();
    }

    private void Delete(){
        PlayerPrefs.DeleteKey("highscoreTable" + level);
    }

    private class Highscores{
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry{
        public int score;
        public string name;
    }
}
