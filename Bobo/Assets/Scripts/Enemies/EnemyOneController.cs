using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOneController : MonoBehaviour 
{ 
    float velocity = 3f;
    static int offset = 8;
    public float health=5f;
    [SerializeField] int typeOfEnemy;
    LayerMask layer;
    BoxCollider2D boxCollider;
    Rigidbody2D rigid;
    private Animator anim;
    [SerializeField] private Behaviour[] components;
    int powerupSpawn;
    //public GameObject Coin;
    public GameObject[] enemyDrops;
    void Start()
    {   
        rigid = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        layer = LayerMask.GetMask("Bullet");
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "FallDetector"){
            anim.SetTrigger("Die");
            if(GetComponent<EnemyFollow>()!=null){
                GetComponent<EnemyFollow>().enabled=false;
                GetComponent<Rigidbody2D>().constraints=RigidbodyConstraints2D.FreezePositionY;
            }
            if(GetComponentInParent<EnemyPatrol>() != null)
            GetComponentInParent<EnemyPatrol>().enabled = false;
            GetComponent<Enemy1>().enabled = false;
            Destroy(gameObject,2f);
        }
    }

    public void IsHit()
    {
        RaycastHit2D ray = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 50f, Vector2.left, .1f, layer);
        //int count=1;
        if (ray.collider && health > 0)
        {   
            anim.SetTrigger("Hurt");
            health-=PlayerStats.damage;
        }
        if(health <= 0){
            boxCollider.enabled = false;
            anim.SetTrigger("Die");
            if(GetComponent<EnemyFollow>()!=null){
                GetComponent<EnemyFollow>().enabled=false;
                GetComponent<Rigidbody2D>().constraints=RigidbodyConstraints2D.FreezePositionY;
            }
            if(GetComponentInParent<EnemyPatrol>() != null)
            GetComponentInParent<EnemyPatrol>().enabled = false;
            GetComponent<Enemy1>().enabled = false;
            if(typeOfEnemy==1){
                PlayerStats.score+=25;
            }
            else{
                PlayerStats.score+=50;
            }
            Destroy(gameObject,2f);
            powerupSpawn = Random.Range(0,enemyDrops.Length);
            Instantiate(enemyDrops[powerupSpawn],transform.position,transform.rotation);
        }
    }
  
}
