using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sawbox2 : MonoBehaviour
{
    public float offset = 500f;
    private double finalPosition;
    private float position;
    bool toLeft = false;
    float velocity = -3f;
    float speedRotate = 2f;
    [SerializeField] private float damage;

    void Start()
    {
        position = transform.position.y;//object original position;
        finalPosition = position - 1.28 * 5;//cinque tile(di grandezza 1.28) a salire
    }

    void Update(){
   //     transform.Rotate(0, 0, -1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.Translate(0, Time.deltaTime * velocity, 0);
        if ((transform.position.y <= finalPosition) && !toLeft)
        {
            velocity = -velocity;
            toLeft = true;
        }
        if ((transform.position.y >= position) && toLeft)
        {
            velocity = -velocity;
            toLeft = false;
        }
    }
}
