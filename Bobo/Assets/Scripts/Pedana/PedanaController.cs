using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedanaController : MonoBehaviour
{
    public float offset = 500f;
    [SerializeField] private float finalPosition= 72.66756f;//particolare posizione del gioco(Bho non ricordo un cazzo)
    private float position;
    bool toLeft = false;
    float velocity=3f;
    void Start()
    {
        position = transform.position.x;//object original position;
    }

    void FixedUpdate()
    {
        transform.Translate(Time.deltaTime * velocity, 0, 0);
        if ((transform.position.x >= finalPosition) && !toLeft)
        {
            velocity = -velocity;
            toLeft = true;
        }
        if ((transform.position.x <= position) && toLeft)
        {
            velocity = -velocity;
            toLeft = false;
        }
    }

}
