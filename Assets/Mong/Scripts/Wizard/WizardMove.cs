using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;

public class WizardMove : StateMachineBehaviour
{
    [SerializeField]
    private Vector2 findTargetSize;

    [SerializeField]
    private PlayerInfo playerInfo;

    [SerializeField]
    private MapBlcok mapBlcok;

    SpriteRenderer render;

    [SerializeField, Range(1, 10)]
    public float wizardMoveSpeed;

    Rigidbody2D rigid;

    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        render = animator.GetComponent<SpriteRenderer>();  
        rigid = animator.GetComponentInParent<Rigidbody2D>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rigid.velocity = new Vector2(wizardMoveSpeed, rigid.velocity.y);

        Collider2D[] collider = Physics2D.OverlapBoxAll(animator.gameObject.transform.position, findTargetSize, 0);

        for (int i = 0; i < collider.Length; i++)
        { 
            playerInfo = collider[i].GetComponent<PlayerInfo>();
            mapBlcok = collider[i].GetComponentInParent<MapBlcok>();

            if (mapBlcok != null && playerInfo == null)
            {
                if (!render.flipX)
                {
                    render.flipX = true;
                    wizardMoveSpeed *= 1;
                }
                else
                {
                    render.flipX = false;
                    wizardMoveSpeed *= -1;

                }
            }
            else if (playerInfo != null)
            {
                animator.SetTrigger("Attack");
            }
        }
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

   
}
