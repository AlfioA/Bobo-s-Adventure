using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellShot : MonoBehaviour
{
   public float speed = 5f;
    public Rigidbody2D rigid;
    public float spawn=0;
    float range = 12f;
    
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
   protected void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
        }
        Destroy(gameObject);
    }
    
    public void SetSpawn(float spawn)
    {
        this.spawn = spawn;
    }
}
