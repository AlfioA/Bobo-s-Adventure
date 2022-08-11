using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{   
    [Header ("Attack Parameters")]    
    [SerializeField] public float attackCoolDown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header ("Collider Parameters")]   
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header ("Player Layer")]  
    [SerializeField]private LayerMask playerLayer;
    public float cooldownTimer = Mathf.Infinity;
    public Animator animator;
    GameObject child;
    
    // Start is called before the first frame update
    void Start()
    {
        child=this.gameObject.transform.GetChild(0).gameObject;
        animator=child.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;
        Attack();    
    }

    void Attack(){
        if(PlayerInSight()){
            animator.SetTrigger("Attack");
            if (cooldownTimer >= attackCoolDown){
                    animator.SetTrigger("Attack");
                    cooldownTimer = 0;
                 
            }
        }
    }

    public bool PlayerInSight(){
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),0,Vector2.left,0, playerLayer);
        return hit.collider != null;
    }

    public void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
}

