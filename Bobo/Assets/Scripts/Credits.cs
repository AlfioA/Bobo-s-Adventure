using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    //public float ColorRate=5f;
    //public float nextColorTime;
    Color[] colors;
    Color actualColor;
    Camera camera;
    Color randomColor;
    float transition;

    int actualIndex;
    int randomIndex;
    
    bool stop=true;

    void Start(){
        transition=0;
        camera=GetComponent<Camera>();
        colors=new Color[7];
        colors[0]=new Color(0.70f,0.26f,0.96f);//viola
        colors[1]=new Color(0.51f,0.96f,0.25f);//verde
        colors[2]=new Color(0.03f,0.55f,0.60f);//azzurro
        colors[3]=new Color(0.96f,0.54f,0.25f);//arancione
        colors[4]=new Color(0.63f,0.16f,0.30f);//fucsia
        colors[5]=new Color(0.13f,0.74f,0.52f);//verde acqua(?)
        colors[6]=new Color(0.28f,0.16f,0.12f);//marrone
        actualColor=colors[Random.Range(0,colors.Length)];
        camera.backgroundColor=colors[actualIndex];
        actualIndex=Random.Range(0,colors.Length);
        randomIndex=Random.Range(0,colors.Length);
        RandomGeneration();
        camera.backgroundColor=colors[actualIndex];
        StopTime();
    }

    void Update()
    {
        if(!stop){
            transition+=Time.deltaTime;
            camera.backgroundColor=Color.Lerp(colors[actualIndex],colors[randomIndex],transition);
        }
        else{
            transition=0;
        }
        if(transition>=1){
            stop=true;
            RandomGeneration();
            transition=0;
            StopTime();
        }
    }

    void RandomGeneration(){
        actualIndex=randomIndex;
        randomIndex=Random.Range(0,colors.Length);
        if(randomIndex==actualIndex){//if you generated two of same cavolicchio DI Colori
            randomIndex=(randomIndex+1)%colors.Length;
        }
    }
    
    void StopTime(){
        StartCoroutine(RestaT());
    }

    IEnumerator RestaT(){
        yield return new WaitForSeconds(3);
        stop=false;
    }
}
