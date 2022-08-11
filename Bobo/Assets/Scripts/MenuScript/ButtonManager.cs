using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{ 
    public void StartGame(string level)
    {
       SceneManager.LoadScene(level);
    }

    public void LoadCredit()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
