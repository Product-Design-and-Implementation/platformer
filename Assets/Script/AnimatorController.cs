using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator mAnimator;
    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mAnimator != null)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                // Player has pressed Space, switch to the jump animation
                isMoving = false;
                mAnimator.SetTrigger("TrJump");
            }
            else if (Input.GetKey(KeyCode.D))
            {
                // Player has pressed D, switch to the run animation
                isMoving = true;
                mAnimator.SetTrigger("TrRun");
            }
            else if (Input.GetKey(KeyCode.S))
            {
                // Player has pressed S, switch to the slide animation
                isMoving = false;
                mAnimator.SetTrigger("TrSlide");
            }
            else
            {
                // None of the specified keys is pressed, trigger the idle animation
                isMoving = false;
                mAnimator.SetTrigger("TrIdle");
            }

            // Check if the character is in the moving state
            if (isMoving)
            {
                // Trigger the looping run animation
                mAnimator.SetTrigger("TrRun");
            }
        }
    }
}
