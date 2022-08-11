using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacEnemySideway : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            PlayerStats.health--;
        }
    }
    private void OnCollisionStay2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            PlayerStats.health--;
        }
    }     
}
