using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingMenu : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    int value;
    void Start()
    {
        value=PlayerPrefs.GetInt("resolution",value);
        Screen.fullScreen = true;
        dropdown.value=value;
        //SetQuality(value);
    }

    public void SetQuality(int qualityIndex)// SetResolution
    {
        switch (qualityIndex)
        {
            case 1:
                Screen.SetResolution(640, 480, Screen.fullScreen);
                break;
            case 0:
                Screen.SetResolution(1280, 720, Screen.fullScreen);
                break;
            case 2:
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
                break;
            case 3:
                Screen.SetResolution(2560, 1440, Screen.fullScreen);
                break;
            default:
                Screen.SetResolution(1280, 720, Screen.fullScreen);
                break;
        }
        PlayerPrefs.SetInt("resolution",qualityIndex);
    }

    public void SetFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
