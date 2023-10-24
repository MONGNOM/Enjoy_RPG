using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WizardDeath : StateMachineBehaviour
{
    [SerializeField] private float mingiveExp;
    [SerializeField] private float maxgiveExp;
    private float giveExp;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        giveExp = Random.Range(mingiveExp, maxgiveExp);
        Warrior warrior = FindObjectOfType<Warrior>();
        warrior.curExp += giveExp;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

   override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
        mingiveExp *= 1.5f;
        maxgiveExp *= 1.5f;
    }

}
