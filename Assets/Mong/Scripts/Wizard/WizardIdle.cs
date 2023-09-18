using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WizardIdle : StateMachineBehaviour
{
    [SerializeField] private int layerMask;
    [SerializeField] private Vector2 findTargetSize;
    [SerializeField] private Warrior warrior;
    [SerializeField] private float idleTime;
    [SerializeField] WizardBoxPosition boxPos;
                     private float idleToTiem;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boxPos = FindObjectOfType<WizardBoxPosition>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        idleToTiem += Time.deltaTime;
        Collider2D findTarget = Physics2D.OverlapBox(boxPos.transform.position, findTargetSize, 0);
        warrior = findTarget.GetComponent<Warrior>();

        if (idleToTiem >= idleTime)
        {
            if (warrior != null)
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
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        idleToTiem = 0;
    }
}
