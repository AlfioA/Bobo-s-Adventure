using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowKey : MonoBehaviour
{

    public GameObject key;

    // Update is called once per frame
    void Update()
    {
        if(PlayerStats.key>0){
            key.SetActive(true);
        }
        else{
            key.SetActive(false);
        }
    }
}
