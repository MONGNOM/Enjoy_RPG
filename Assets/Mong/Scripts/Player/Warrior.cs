using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.UI;

public class Warrior : PlayerInfo
{
    public AttackColider attackColider;
    private Animator anim;
    public PlayerController player;
    public UnityEvent inter;
    [SerializeField]
    private Animator skillEffectAnimator;


    private void Awake()
    {
        base.Awake();
        anim = GetComponentInChildren<Animator>();
        attackColider = GetComponentInChildren<AttackColider>();

    }

    private void Start()
    {
        base.Start();
        anim.SetFloat("CurHp", curHp);
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
        if (!player.interaction)
        {
            anim.SetTrigger("Attack");
            if (!anim.GetBool("Grounded"))
            {
                anim.ResetTrigger("Attack");
            }
        }
        else
        {
            //â��â �����ֱ� �ż���
            inter?.Invoke();
        }

    }

    private void OnSkill(InputValue value)
    {
        if (!SkillManager.Instance.outslots[0].skilldata)
            return;

        //��ų���ż��� 
        str += SkillManager.Instance.skillData.damageup;
    }

    private void OnSkill2(InputValue value)
    {
        //��ų���ż���
        if (!SkillManager.Instance.outslots[1].skilldata)
            return;

        skillEffectAnimator.SetTrigger("PowerStrikeEffect");
        anim.SetTrigger("PowerStrike");
    }
}
