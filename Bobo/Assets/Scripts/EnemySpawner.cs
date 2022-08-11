using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemy;

    public float spawnRate=10f;
    public float nextSpawn;

    void Start(){
        PlayerStats.wave=1;
    }

    void Update(){
        if (Time.time>nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            //SoundManagerScript.Instance.PlaySound("shoot");
            Spawn();
        }
    }

    void Spawn(){
        int randEnemy = Random.Range(0, enemy.Length);
        int randSpawnPoints = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy[randEnemy], spawnPoints[randSpawnPoints].position, transform.rotation);
        if(PlayerStats.score>=100 && PlayerStats.wave==1){
            spawnRate-=0.5f;
            PlayerStats.wave++;
        }
        if(PlayerStats.score>=200 && PlayerStats.wave==2){
            spawnRate-=0.5f;
            PlayerStats.wave++;
        }
        if(PlayerStats.score>=400 && PlayerStats.wave==3){
            spawnRate-=0.5f;
            PlayerStats.wave++;
        }
        if(PlayerStats.score>=800 && PlayerStats.wave==4){
            spawnRate-=0.5f;
            PlayerStats.wave++;
        }
        if(PlayerStats.score>=1600 && PlayerStats.wave==5){
            spawnRate-=0.5f;
            PlayerStats.wave++;
        }
        if(PlayerStats.score>=3200 && PlayerStats.wave==6){
            spawnRate-=0.5f;
            PlayerStats.wave++;
        }
        if(PlayerStats.score>=6400 && PlayerStats.wave==7){
            spawnRate-=0.5f;
            PlayerStats.wave++;
        }
        if(PlayerStats.score>=9600 && PlayerStats.wave==8){
            spawnRate-=0.5f;
            PlayerStats.wave++;
        }
        if(PlayerStats.score>=12500 && PlayerStats.wave==9){
            spawnRate-=0.5f;
            PlayerStats.wave++;
        }
        if(PlayerStats.score>=15000 && PlayerStats.wave==10){
            spawnRate-=0.5f;
            PlayerStats.wave++;
        }
    }
}
