using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardDeath : StateMachineBehaviour
{
    private float dietoTime;

    [SerializeField, Range(0, 10f)]
    private float dieTime;
   override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
   }

   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
        dietoTime += Time.deltaTime;
        if (dieTime <= dietoTime)
        { 
            Debug.Log("Á×¾î¼­ »ç¶óÁü");
            Destroy(animator.gameObject.transform.root.gameObject);
        }
   }

   override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
       
   }

}
