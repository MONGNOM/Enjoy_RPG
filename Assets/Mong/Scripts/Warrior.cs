using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : PlayerInfo
{
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
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
        }
    }

    
}
