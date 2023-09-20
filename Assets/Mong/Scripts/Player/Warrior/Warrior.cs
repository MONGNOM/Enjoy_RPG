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
    
    [HideInInspector] public PlayerController player;
    [HideInInspector] public float maxHp;
    [HideInInspector] public float maxMp;
    [HideInInspector] public float maxExp = 100;
    [HideInInspector] public float maxLevel = 10;

    [Header("스탯")]
    public float curHp;
    public float curMp;
    public float curExp = 0;
    public float curLevel = 1;
    
    [Header("공격력")]
    [Range(0, 100f)]
    public float str;

    [Header("스킬마나")]
    [SerializeField, Range(0, 100f)] private float strikeMp;
    [SerializeField, Range(0, 100f)] private float buffMp;

    [SerializeField] private Animator skillEffectAnimator;

    [Header("이벤트")]
    public UnityEvent warriorDie;
    public UnityEvent inter;

    public float EXP
    {
        get { return curExp; }
        set { curExp = value; }
    }
    public bool Death
    { 
        get { return anim.GetBool("Die"); }
        private set { anim.SetBool("Die", value); }
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


        if (curExp >= maxExp && !anim.GetBool("Die"))
        {
            if (curLevel >= maxLevel)
                return;

            Leveup();
        }
    }

    public void Leveup()
    {
        
        maxExp *= 1.5f;
        maxHp *= 2f;
        maxMp *= 0.5f;
        curHp = maxHp;
        curMp = maxMp;
        curLevel++;
        
    }

    public void Resurrection()
    {
        anim.SetBool("Die", false);
        curHp = maxHp;
        curMp = maxMp;
        curExp =  curExp / 5;
        rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
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
    public float Attackdamage()
    {
        float randomdamage = Random.Range(-str * 0.5f, str * 0.5f);
        float damage = str + randomdamage;
        return damage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        //if (collision.CompareTag("Monster"))
        //{
        //    Wizard wizard = null;
        //    collision.gameObject.TryGetComponent<Wizard>(out wizard);
        //    if (wizard == null)
        //        return;
        //    else
        //    {
        //        //TakeHit(wizard.Damage);
        //        wizard.Takehit(str);
        //        Debug.Log("ad");
        //    }
        //}
    }
}
