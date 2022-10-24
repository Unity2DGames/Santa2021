using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_script : MonoBehaviour
{
    Animator animator;
    private string currentState;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void changeAnimationState(string newState){

        //stop playing the same animation and interrupting itself
        if(currentState==newState){
            return;
        }
        //play animation 
        animator.Play(newState);

        //resign the current state
        currentState=newState;
    }
    void Update()
    {
        
    }
}
