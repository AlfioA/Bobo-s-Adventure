using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MyDialogueScript : MonoBehaviour
{
    [SerializeField] int npcID;
    public GameObject dialogueBox;
    public Text text;
    delegate void MyDelegate();
    MyDelegate myDelegate;

    void Start(){
        dialogueBox.SetActive(false);
        if(npcID==1){
            myDelegate=FirstTutorial;
        }
        else if(npcID==2){
            myDelegate=SecondTutorial;
        }
        else if(npcID==3){
            myDelegate=ThirdTutorial;
        }
        else if(npcID==4){
            myDelegate=FourthTutorial;
        }
        else{
            myDelegate=FifthTutorial;
        }
    }
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Player"){
            myDelegate();
            dialogueBox.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        if(collision.tag == "Player"){
            dialogueBox.SetActive(false);
        }
    }

    void FirstTutorial(){
        text.text="Welcome to this game, have fun collecting all the coins around this level!";
    }
    void SecondTutorial(){
        text.text=string.Concat("Press ",GameInputManager.defaults[1]," to Jump.");
    }

    void ThirdTutorial(){
        text.text=string.Concat("Hold "+GameInputManager.defaults[0]+" to Shoot.");
    }

    void FourthTutorial(){
        text.text="Go near that chest and Press E to open it.";
    }

    void FifthTutorial(){
        text.text="You'll need a key to open this gate, maybe you'll find it UP... Sky awaits you!";
    }
}
