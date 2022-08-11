using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    void Start()
    {
        GetComponent<AudioSource>().enabled=true;
        GetComponent<AudioSource>().Play();
    }
}
