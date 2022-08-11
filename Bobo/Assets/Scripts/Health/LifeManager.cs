using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    [SerializeField] GameObject[] hearts;
    Image colors;
    Image originalImage;
    private int life;
    private bool dead;
    //DeathMenu DM;
    //private int maxlife;
    void Start()
    {
        life = 3;
        dead = false;
        for (int i = 0; i < 3; i++)
        {
            hearts[i].GetComponent<Image>().color = Color.red;
        }
        //maxlife = life;
    }

    void Update()
    {
        if (dead == true)
        {
            Debug.Log("Game Over");
        }
    }

    public void takeDamage(int damage)
    {
        Debug.Log("Ehilà c'è nessuno?"+life);
        if (life >= 1)
        {
            life -= damage;
            DarkeningLife();
            //Destroy(hearts[life].gameObject);
            if (life < 1)
            {
                life = 1;
                dead = true;
                //GameEvents.Instance.TriggerOnPlayerDeath();
                //DM.OnEnable();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))//takeDamage
        {
            Debug.Log("Ho preso danno");
            takeDamage(1);
        }
    }


    void DarkeningLife()// quando si perde un cuore lo si fa diventare nero
    {
        colors = hearts[life].GetComponent<Image>();
        colors.color = Color.black;
       /* Color temp = colors.color;
        temp.a = 200;
        colors.color = temp;*/
    }

    void GainLife()
    {
        colors = hearts[life].GetComponent<Image>();
        colors.color = Color.red;
    }
}
