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


    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        attackColider = GetComponentInChildren<AttackColider>();

    }

    private void Start()
    {

    }
    private void Update()
    {
    }

    protected override void PlayerAttack()
    {

    }

    public void AttackStart()
    {
        attackColider.AttackColiderEnable();
    }
    
    public void AttackEnd() 
    {
        attackColider.AttackColiderDisable();
    }

    private void OnAttack(InputValue value)
    {
        Debug.Log("공격감지");
        anim.SetTrigger("Attack");
        if (!anim.GetBool("Grounded"))
        {
            anim.ResetTrigger("Attack");
        }
    }

    private void OnSkill(InputValue value)
    {
        Debug.Log("워리어 스킬");
    }
}
