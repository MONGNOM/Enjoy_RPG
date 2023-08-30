using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.UI;

public class Warrior : PlayerInfo
{
    public AttackColider attackColider;
    private Animator anim;
    private PlayerInput input;



    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        attackColider = GetComponentInChildren<AttackColider>();
        input = GetComponent<PlayerInput>();

    }


    private void Update()
    {
        PlayerAttack();
    }

    protected override void PlayerAttack()
    {
       
        if (input.actions["Attack"].triggered)
        {
            Debug.Log("공격감지");
            anim.SetTrigger("Attack");
            if (!anim.GetBool("Grounded"))
            {
                anim.ResetTrigger("Attack");
            }
        }
    }

    public void AttackStart()
    {
        attackColider.AttackColiderEnable();
    }
    
    public void AttackEnd() 
    {
        attackColider.AttackColiderDisable();
    }

    
}
