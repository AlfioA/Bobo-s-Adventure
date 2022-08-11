using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearthSystem : MonoBehaviour
{
    public GameObject[] hearts;
    private int life;
    private bool dead;

    void Start()
    {
        dead = false;
    }

    void Update()
    {
        if(dead == true){
            Debug.Log("Game Over");
        }
    }

    public void takeDamage(int damage){
        if(life >= 1){
            life -= damage;
            Destroy(hearts[life].gameObject);
            if(life < 1){

                dead = true;
            }
        }
    }
}
