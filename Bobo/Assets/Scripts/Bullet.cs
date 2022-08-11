using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rigid;
    public float spawn=0;
    float range = 8f;
    
    // Start is called before the first frame update
    void Start()
    {
        rigid.velocity = transform.right * speed;
    }

    private void LateUpdate()
    {
        if (Mathf.Abs(transform.position.x - spawn) > range)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {   
        
        EnemyOneController enemy = hitInfo.GetComponent<EnemyOneController>();
 
        if(enemy != null && enemy.health>0){
            enemy.IsHit();
        }
        Destroy(gameObject); 

    }
    
    public void SetSpawn(float spawn)
    {
        this.spawn = spawn;
    }
}
