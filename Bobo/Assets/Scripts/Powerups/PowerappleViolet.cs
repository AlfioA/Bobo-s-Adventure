using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerappleViolet : MonoBehaviour
{
   [SerializeField] public Image apple;
   SpriteRenderer sprite;
   BoxCollider2D box;

    void Start(){
        apple.enabled = false;
        box = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
  //      PlayerStats.damage = 1;
  //      PlayerStats.purpleShot=false;
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
        Debug.Log("PowerappleViolet!"); 
        apple.enabled = true;
        PlayerStats.damage = 100;
        PlayerStats.purpleShot=true;
        yield return new WaitForSeconds(10);
        PlayerStats.purpleShot=false;
        PlayerStats.damage = 1;
        apple.enabled = false;
        Destroy(gameObject);
    }
}
