using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject foxy;
    float offset = 1.5f;
    float horizontalMove;
    float verticalMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        transform.position=new Vector3(foxy.transform.position.x,foxy.transform.position.y,foxy.transform.position.z-50);
    }
}
