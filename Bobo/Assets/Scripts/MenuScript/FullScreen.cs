using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreen : MonoBehaviour
{
    void Start()
    {
        Screen.fullScreen = false;
    }

    public void SetFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

}
