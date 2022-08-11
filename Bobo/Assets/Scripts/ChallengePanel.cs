using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengePanel : MonoBehaviour
{

    public GameObject startingChallenge;
    public GameObject pauseMenu;
    void Start()
    {
        pauseMenu.GetComponent<PauseMenu>().enabled=false;
        Time.timeScale=0;
        startingChallenge.SetActive(true);
    }

    public void Starting(){
        pauseMenu.GetComponent<PauseMenu>().enabled=true;
        startingChallenge.SetActive(false);
        Time.timeScale=1;
    }
}
