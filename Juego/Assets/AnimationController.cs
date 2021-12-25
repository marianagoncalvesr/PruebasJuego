using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : StateMachineBehaviour
{

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        try
        {
            animator.SetBool("isAttacking", false);
            GameObject.FindWithTag("TailHitBox").GetComponent<BoxCollider>().enabled = false;

        }
        catch (System.Exception ex)
        {

            throw;
        }
   

    }


}
