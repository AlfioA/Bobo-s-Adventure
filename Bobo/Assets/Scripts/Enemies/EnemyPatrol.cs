using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{   

    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    //[SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;


    

    private void Awake(){
        initScale = transform.localScale;
    }

    private void MoveInDirection(int _direction){
        transform.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);
        transform.position = new Vector3(transform.position.x + Time.deltaTime * _direction * speed, transform.position.y, transform.position.z);

    }


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(movingLeft){
            if(transform.position.x >= leftEdge.position.x){
                MoveInDirection(-1);
            }
            else{
                DirectionChange();
            }
        }
        else{
            if(transform.position.x <= rightEdge.position.x){
                MoveInDirection(1);
            }
            else{
                DirectionChange();
            }
        }
    }

    private void DirectionChange(){
        movingLeft = !movingLeft;
    }

}
