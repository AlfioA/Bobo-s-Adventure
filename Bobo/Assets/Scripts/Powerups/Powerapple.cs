using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Powerapple : MonoBehaviour
{   
   [SerializeField] public Image apple;
   SpriteRenderer sprite;
   BoxCollider2D box;

    void Start(){
        apple.enabled = false;
        box = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            sprite.enabled = false;
            box.enabled = false;
            PlayerStats.score+=20;
            StartCoroutine(Pickup(other));
        }
    }

    public IEnumerator Pickup(Collider2D player){
        //Debug.Log("Powerapple!"); 
        apple.enabled = true;
        Weapon weapon = player.GetComponent<Weapon>();
        weapon.fireRate = 0.2f;
        PlayerStats.shootRate=true;
        yield return new WaitForSeconds(10);
        PlayerStats.shootRate=false;
        weapon.fireRate = 0.4f;
        apple.enabled = false;
        Destroy(gameObject);
    }
}
