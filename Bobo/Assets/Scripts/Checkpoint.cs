using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{   
    ScriptToLoad saving;
    private GameObject flag;
    SpriteRenderer sprite;
    [SerializeField] int typeCheck;
    bool i=true;

    void Start(){
        saving=new ScriptToLoad();
        if(PlayerStats.hardMode==true){
            gameObject.SetActive(false);
        }
        flag= transform.Find("Bandierina").gameObject;
        sprite = flag.GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            if(i==true){
                if(typeCheck!=0){
                    sprite.color = Color.green;
                }
                PlayerStats.checkpoint=typeCheck;
                saving.Saving();
                i=false;//i checkpoint possono funzionare una sola volta
            }
        }
    }
}
