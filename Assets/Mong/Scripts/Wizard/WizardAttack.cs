using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAttack : StateMachineBehaviour
{
    [SerializeField]
    private Vector2 findTargetSize;

    [SerializeField]
    private PlayerInfo playerInfo;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
   }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Collider2D colider = Physics2D.OverlapBox(animator.gameObject.transform.position, findTargetSize, 0);
        playerInfo = colider.GetComponent<PlayerInfo>();
        if (!playerInfo)
        {
            animator.SetTrigger("Idle");
        }
   }

   override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
       
   }

    
}
