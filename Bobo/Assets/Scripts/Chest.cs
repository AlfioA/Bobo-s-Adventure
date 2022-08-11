using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Chest : MonoBehaviour
{
    Animator animator;
    public Animator keyAnimator;
    public bool open;
    void Awake()
    {
        open=false;
        animator = GetComponent<Animator>();
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag=="Player" && Input.GetKey("e"))
        {
            animator.SetBool("Opening", true);
            keyAnimator.SetBool("Open",true);
            StartCoroutine(waitForTakeKey(90));//wait the animation to finish 
        }
    }

    public IEnumerator waitForTakeKey(float keyDurationAnim)
    {
        yield return new WaitForSeconds(1);
        open=true;//you can finally get the key
    }
 
}
