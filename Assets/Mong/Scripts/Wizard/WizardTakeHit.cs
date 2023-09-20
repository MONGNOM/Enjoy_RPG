using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardTakeHit : StateMachineBehaviour
{
    [SerializeField]
    private Wizard wizard;
    [SerializeField]
    private Warrior warrior;
   override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      wizard = animator.GetComponentInParent<Wizard>();
      wizard.curHp -= wizard.damageWarrior;
      wizard.damageWarrior = 0;
    }

   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
       
   }

   override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
        
   }

   
}
