using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : PlayerInfo
{
    public AttackColider attackColider;
    private Animator anim;
   
  

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        attackColider = GetComponentInChildren<AttackColider>();
    }

    
    private void Update()
    {
        PlayerAttack();
        
    }
    protected override void PlayerAttack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
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
