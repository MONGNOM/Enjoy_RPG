using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardDeath : StateMachineBehaviour
{
    private float dietoTime;

    [SerializeField, Range(0, 10f)] private float dieTime;
    private float giveExp;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
        giveExp = Random.Range(100, 500f);
   }

   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
        dietoTime += Time.deltaTime;
        Warrior warrior = FindObjectOfType<Warrior>();
        if (dieTime <= dietoTime)
        {
            warrior.curExp += giveExp;
            Destroy(animator.gameObject.transform.root.gameObject);
        }
    }

   override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
        
   }

}
