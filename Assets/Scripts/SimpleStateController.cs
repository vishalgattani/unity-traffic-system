using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        
    }

    // Update is called once per frame
    void Update(){
        bool isWalking = animator.GetBool(isWalkingHash);
        bool forwardPress = Input.GetKey(KeyCode.W);
        if (!isWalking && forwardPress){
            animator.SetBool(isWalkingHash, true);
        }
        if (isWalking && !forwardPress){
            animator.SetBool(isWalkingHash, false);
        }
    }

}
