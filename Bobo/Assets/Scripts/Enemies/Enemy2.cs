using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy1
{
    [SerializeField]GameObject Foxy;
    SpriteRenderer sprite;
    public Transform firePoint;
    public SpellShot shot;

    bool facingRight;

    void Start(){
        Foxy=GameObject.Find("foxy");
        sprite=GetComponent<SpriteRenderer>();
        animator=GetComponent<Animator>();
        facingRight=true;
    }

    void Update(){
        Face();
        cooldownTimer += Time.deltaTime;
        Attack();
    }
    void Attack(){
        if(PlayerInSight()){
           // animator.SetTrigger("rangedAttack");
            if (cooldownTimer >= attackCoolDown){
                    animator.SetTrigger("rangedAttack");
            }
        }
    }

    void Sparo(){ //richiamato dall'animator
        shot.SetSpawn(transform.position.x);
        Instantiate(shot, firePoint.position, firePoint.rotation);
    }

    void Face(){
        if ((Foxy.transform.position.x<transform.position.x && facingRight) || (Foxy.transform.position.x>transform.position.x && !facingRight))
		{
			Flip();
		}
    }

    void Flip(){
        facingRight = !facingRight;

		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;
		transform.localScale = flipped;

		transform.Rotate(0f, 180f, 0f);
    }
}
