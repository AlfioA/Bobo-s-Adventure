using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedanatwo : MonoBehaviour
{
    public float offset = 500f;
    private double finalPosition;
    private float position;
    bool toLeft = false;
    float velocity = 3f;
    void Start()
    {
        position = transform.position.y;//object original position;
        finalPosition = position + 1.28 * 9.7f;//nove tile(di grandezza 1.28) a salire
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0, Time.deltaTime * velocity, 0);
        if ((transform.position.y >= finalPosition) && !toLeft)
        {
            velocity = -velocity;
            toLeft = true;
        }
        if ((transform.position.y <= position) && toLeft)
        {
            velocity = -velocity;
            toLeft = false;
        }
    }
}
