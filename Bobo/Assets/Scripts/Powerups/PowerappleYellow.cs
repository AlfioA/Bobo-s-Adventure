using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerappleYellow : MonoBehaviour
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
        Debug.Log("PowerappleYellow!"); 
        apple.enabled = true;
        player.GetComponent<Health>().YellowApple();
        yield return new WaitForSeconds(10);
        apple.enabled = false;
        Destroy(gameObject);
    }
}
