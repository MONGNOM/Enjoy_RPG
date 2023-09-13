using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WizardIdle : StateMachineBehaviour
{
    [SerializeField]
    private int layerMask;

    [SerializeField]
    private Vector2 findTargetSize;

    [SerializeField]
    private PlayerInfo playerInfo;

    

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        Collider2D findTarget = Physics2D.OverlapBox(animator.gameObject.transform.position, findTargetSize, 0);
           playerInfo = findTarget.GetComponent<Warrior>();

            if (playerInfo != null)
            {
                Debug.Log("공격");
                animator.SetTrigger("Attack");
            }
            else
            {
                Debug.Log("이동");
                animator.SetTrigger("Move");
            }
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        

    }
}
