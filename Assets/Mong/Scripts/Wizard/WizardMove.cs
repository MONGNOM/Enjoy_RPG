using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;

public class WizardMove : StateMachineBehaviour
{
    [SerializeField] private Vector2 findTargetSize;

    [SerializeField] private Warrior warrior;

    [SerializeField, Range(1, 10)] public float wizardMoveSpeed;

    [SerializeField] WizardBoxPosition boxPos;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boxPos = FindObjectOfType<WizardBoxPosition>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.root.Translate(new Vector3(wizardMoveSpeed, 0, 0) * Time.deltaTime);
        Collider2D collider = Physics2D.OverlapBox(boxPos.transform.position, findTargetSize, 0);
        warrior = collider.GetComponent<Warrior>();
        if (warrior != null)
        {
            Debug.Log("플레이어가 범위 안에있음");
            animator.SetTrigger("Attack");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}

   

