using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{   
    [SerializeField] GameObject Foxy;
    public float speed;
    public float stoppingDistance;
    bool facingRight;

    private Transform target;

    void Start(){
        facingRight = true;
        Foxy=GameObject.Find("foxy");
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update(){
        Face();
        if(Vector2.Distance(transform.position, target.position) > stoppingDistance){
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
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
