using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.UI;

public class Warrior : MonoBehaviour
{
    private AttackColider attackColider;
    private Animator anim;
    private Wizard wizard;
    private Rigidbody2D rigid;
    
    [Header("스탯")]
    [HideInInspector] public PlayerController player;
    [HideInInspector] public float maxHp;
    [HideInInspector] public float maxMp;
    [HideInInspector] public float maxExp = 100;
    [HideInInspector] public float maxLevel = 10;

    public float curHp;
    public float curMp;
    public float curExp = 0;
    public float curLevel = 1;
    
    [Header("공격력")]
    [Range(0, 100f)]
    public float str;

    [Header("스킬필요Mp")]
    [SerializeField, Range(0, 100f)] private float strikeMp;
    [SerializeField, Range(0, 100f)] private float buffMp;

    [SerializeField] private Animator skillEffectAnimator;

    [Header("이벤트")]
    public UnityEvent warriorDie;
    public UnityEvent inter;

    public bool Death
    { 
        get { return anim.GetBool("Die"); }
    }



    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        attackColider = GetComponentInChildren<AttackColider>();
    }

    private void Start()
    {
        curHp = maxHp;
        curMp = maxMp;
        anim.SetFloat("CurHp", curHp);
        wizard = FindObjectOfType<Wizard>();
    }
    private void Update()
    {
        if (curHp <= 0)
        {
            warriorDie?.Invoke();
        }


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
        anim.SetBool("Die",true);
        rigid.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void TakeHit(float damage)
    {
        curHp -= damage;
        anim.SetTrigger("Hurt");
    }

    public void UseSkill(float mp)
    {
        curMp -= mp;
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
            TakeHit(wizard.Damage);
        }
    }
}
