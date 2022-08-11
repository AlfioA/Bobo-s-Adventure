using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySideways : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.collider.tag == "Player"){
            collision.collider.GetComponent<Health>().TakeDamage(damage);
        }
    }
    private void OnCollisionStay2D(Collision2D collision){
        if(collision.collider.tag == "Player"){
            collision.collider.GetComponent<Health>().TakeDamage(damage);
        }
    }     
}
