using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudTransparency : MonoBehaviour
{
    float alpha=0.5f;
    SpriteRenderer r;
    void Start(){ 
        r=gameObject.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Player"){
            Color tmp=r.color;
        
            tmp.a=alpha;
           
            r.color=tmp;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag=="Player"){
            Color tmp=r.color;
        
            tmp.a=1;
           
            r.color=tmp;
        }
    }
}
