using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public Bullet bullet;
    public GameObject foxy;
    [SerializeField]PlayerController player;
    private float nextFire;
    public float fireRate = 0.4f;
    public float damage = 1f;
    void Update()
    {
        if (GameInputManager.GetKey("Shoot") && player.isGround && Time.time>nextFire)
        {
            nextFire = Time.time + fireRate;
            SoundManagerScript.Instance.PlaySound("shoot");
            Shoot();
        }
   
    }

    void Shoot()
    {
        bullet.SetSpawn(transform.position.x);
        if(PlayerStats.purpleShot){
            bullet.GetComponent<SpriteRenderer>().color=new Color(0.56f,0.01f,0.99f);
        }
        else{
            bullet.GetComponent<SpriteRenderer>().color=new Color(0.99f,0.90f,0.01f);
        }
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
