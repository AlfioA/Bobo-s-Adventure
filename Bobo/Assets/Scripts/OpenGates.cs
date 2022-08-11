using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGates : MonoBehaviour
{
    public GameObject key;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag=="Player" && PlayerStats.key!=0)
        {
            PlayerStats.key--;
            gameObject.SetActive(false);
            key.SetActive(false);
        }
    }
}
