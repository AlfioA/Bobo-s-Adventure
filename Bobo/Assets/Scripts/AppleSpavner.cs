using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpavner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] apple;

    public float spawnRate=10f;
    public float nextSpawn;
    void Start(){

    }

    void Update(){
        if (Time.time>nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            Spawn();
        }
    }

    void Spawn(){
        int randApple = Random.Range(0, apple.Length);
        int randSpawnPoints = Random.Range(0, spawnPoints.Length);
        Instantiate(apple[randApple], spawnPoints[randSpawnPoints].position, transform.rotation);
    }
}
