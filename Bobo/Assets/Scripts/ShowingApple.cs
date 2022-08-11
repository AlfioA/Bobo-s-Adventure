using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowingApple : MonoBehaviour
{
    [SerializeField]Image Red;
    [SerializeField]Image Violet;
    [SerializeField]Image Yellow;
    void Start(){
        Red.enabled=false;
        Violet.enabled=false;
        Yellow.enabled=false;
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag=="PurplerApple"){
            Violet.enabled=true;
            StartCoroutine(waiting(10,Violet));
        }
        else if(other.tag=="YellowerApple"){
            Yellow.enabled=true;
            StartCoroutine(waiting(10,Yellow));
        }
        else if(other.tag=="RedApple"){
            Red.enabled=true;
            StartCoroutine(waiting(10,Red));
        }
    }
    public IEnumerator waiting(int sec,Image image){
        yield return new WaitForSeconds(sec);
        image.enabled=false;
    }
}
