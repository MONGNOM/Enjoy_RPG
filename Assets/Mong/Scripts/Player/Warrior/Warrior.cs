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
    }
    private void Update()
    {
        if (curExp >= maxExp)
        {
            if (curLevel >= maxLevel)
                return;

            Leveup();
        }
    }

    public void Leveup()
    {
        curExp = 0;
        maxExp *= 1.5f;
        maxHp *= 2f;
        maxMp *= 0.5f;
        curHp = maxHp;
        curMp = maxMp;
        curLevel++;
    }
    public void Die()
    {
        anim.SetTrigger("Die");
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
            //창고창 열어주기 매서드
            inter?.Invoke();
        }

    }

    private void OnSkill(InputValue value)
    {
        if (!SkillManager.Instance.outslots[0].skilldata)
            return;

        //스킬사용매서드 
        skillEffectAnimator.SetTrigger("PowerUp");
        str += SkillManager.Instance.skillData.damageup;
    }

    private void OnSkill2(InputValue value)
    {
        //스킬사용매서드
        if (!SkillManager.Instance.outslots[1].skilldata)
            return;

        skillEffectAnimator.SetTrigger("PowerStrikeEffect");
        anim.SetTrigger("PowerStrike");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            curHp -= 30;
        }
    }
}
