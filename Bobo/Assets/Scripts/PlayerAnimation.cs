using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{   
    public PlayerController foxy;
    public SpriteRenderer spriterenderer;
    public Animator animator;
    void Start()
    {
        animator.SetBool("Shooting",false);
        animator.SetBool("IperShooting",false);
        PlayerStats.shootRate=false;
    }


    void Update()
    {
        Move();
        Jump();
        Shoot();
    }
    void Move()
    {
        if((!(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))) && (!(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)))){
            animator.SetFloat("Speed", System.Math.Abs(foxy.horizontalMove));
        }
        else{
            animator.SetFloat("Speed",0);
        }
    }

    void Jump()
    {
        if (!foxy.isGround){
            animator.SetFloat("Height", 1);
        }
        else
        {
            animator.SetFloat("Height", 0);
        }
    }

    void Shoot()
    {
        if (foxy.shooting)
        {
            animator.SetBool("Shooting", true);
            if(PlayerStats.shootRate){
                animator.SetBool("IperShooting",true);
            }
            else{
                animator.SetBool("IperShooting",false);
            }
        }
        else
        {
            animator.SetBool("Shooting", false);
        }
    }
}

