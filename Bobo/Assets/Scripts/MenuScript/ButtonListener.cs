using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;//bottoni spocchiosi

public class ButtonListener : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI jumpText;
    [SerializeField] TextMeshProUGUI shootText;
    Event keyEvent;
    bool waitingForKey;
    KeyCode newKey;
    KeyCode newJumpKey;
    KeyCode newShootKey;

    void Start()
    {
        waitingForKey = true;
      //  KeyCode newJumpKey = KeyCode.Z;
       // KeyCode newShootKey = KeyCode.X;
    }


    public void ChangeJumpButton()
    {
        StartAssignment();
        newJumpKey = newKey;
        if (newShootKey == newJumpKey)
        {
            return;
        }
        else if (newKey != KeyCode.None)
        {
            GameInputManager.SetKeyMap("Jump", newJumpKey);
            jumpText.text = newJumpKey.ToString();
        }
        else
        {
            GameInputManager.SetKeyMap("Jump", KeyCode.Z);
            jumpText.text = "Z";
        }
    }

    public void ChangeShootButton()
    {
        StartAssignment();
        newShootKey = newKey;
        if(newShootKey==newJumpKey)
        {
            return;
        }
        else if (newShootKey != KeyCode.None)
        {
            GameInputManager.SetKeyMap("Shoot", newShootKey);
            shootText.text = newKey.ToString();
        }
        else
        {
            GameInputManager.SetKeyMap("Shoot", KeyCode.X);
            shootText.text ="X";
        }
    }

    void OnGUI()
    {
        keyEvent = Event.current;
        if (keyEvent.isKey && waitingForKey)
        {
            newKey = keyEvent.keyCode;
            waitingForKey = false;
        }
    }

    public void StartAssignment()
    {
        if (!waitingForKey)
            StartCoroutine(AssignKey());
    }

    IEnumerator WaitForKey()
    {
        while (!keyEvent.isKey)
        {
            yield return null;
        }
    }

    public IEnumerator AssignKey()
    {
        waitingForKey = true;
        yield return WaitForKey();
    }

}

