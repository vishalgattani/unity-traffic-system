using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update(){
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool forwardPress = Input.GetKey(KeyCode.W);
        bool run = Input.GetKey("left shift");
        if (!isWalking && forwardPress){
            animator.SetBool(isWalkingHash, true);
        }
        if (isWalking && !forwardPress){
            animator.SetBool(isWalkingHash, false);
        }
        if(!isRunning && forwardPress && run){
            animator.SetBool(isRunningHash, true);
        }
        if (isRunning && (!forwardPress || !run)){
            animator.SetBool(isRunningHash, false);
        }
    }

}
