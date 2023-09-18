using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using UnityEngine;

public class WizardAttack : StateMachineBehaviour
{
    [SerializeField] private Vector2 findTargetSize;
    [SerializeField] private Warrior warrior;
    [SerializeField] WizardBoxPosition boxPos;
    [SerializeField] BoxCollider2D attackcollider;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
        boxPos = FindObjectOfType<WizardBoxPosition>();
        attackcollider = animator.GetComponentInParent<BoxCollider2D>();
        attackcollider.enabled = true;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Collider2D colider = Physics2D.OverlapBox(boxPos.transform.position, findTargetSize, 0);
        warrior = colider.GetComponent<Warrior>();
        if (warrior == null)
        {
            animator.SetTrigger("Idle");
        }
        else
        { 
            animator.SetTrigger("Attack");
        }
    }

   override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
        attackcollider.enabled = false;
   }

    
}
