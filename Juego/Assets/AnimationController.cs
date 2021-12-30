using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : StateMachineBehaviour
{


    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    //    if (animator.GetBool("isAttacking"))
    //        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().AttackProtection();


    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        try
        {
            if (animator.GetBool("isAttacking"))
            {
                animator.SetBool("isAttacking", false);
                GameObject.FindWithTag("TailHitBox").GetComponent<SphereCollider>().enabled = true;
            }
         

        }
        catch (System.Exception ex)
        {

            throw;
        }


    }


}
