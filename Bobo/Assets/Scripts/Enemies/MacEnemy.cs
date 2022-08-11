using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacEnemy : MonoBehaviour
{
    public GameObject Foxy;
    static float activationDistance = 2.56f;// 1 tile block
    float InitialHeight;//altezza iniziale di questo quadrato spinato
    float distance;
    Rigidbody2D rigid;
    BoxCollider2D boxCollider;
    LayerMask layer;
    bool rising;
    static float activationAnimationDistance = 3.84f;
    Animator animator;

    void Start()
    {
        rising = false;//il blocco sta fermo
        rigid = GetComponent<Rigidbody2D>();
        InitialHeight = transform.position.y;
        rigid.gravityScale = 0;
        boxCollider = GetComponent<BoxCollider2D>();
        layer = LayerMask.GetMask("Ground");
        distance = 1.29f;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        distance = Mathf.Abs(Foxy.transform.position.x - transform.position.x);
        if (distance <= activationAnimationDistance && !rising) //controllo animazione in base alla distanza
        {
            animator.SetBool("hate", true); //attiva animazione quadrato spinato
        }
        else
        {
            animator.SetBool("hate", false);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (rising == false)//pronto a schiacciare il personaggio
        {
            distance = Mathf.Abs(Foxy.transform.position.x - transform.position.x);
            if (distance <= activationDistance)
            {
                rigid.gravityScale = 3;
            }
            RaycastHit2D ray = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 50f, Vector2.down, .1f, layer);
            if (ray.collider)
            {
                rising = true;
            }
        }
        else// in fase di attivazione 
        {
            if (transform.position.y <= InitialHeight)
            {
                rigid.gravityScale = -0.05f;
                animator.SetBool("hate", false);//togli animazione quadrato spinato quanda sta scaricando la sua ira
            }
            else
            {
                rigid.velocity = new Vector2(0,0);
                rigid.gravityScale = 0;
                rising = false;
            }
        }
    }
}
