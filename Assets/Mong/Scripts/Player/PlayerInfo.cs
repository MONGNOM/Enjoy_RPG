using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public abstract class PlayerInfo : MonoBehaviour
{
    [SerializeField]
    protected float maxHp;
    [SerializeField]
    protected float curHp;

    [SerializeField]
    protected float maxMp;
    protected float curMp;

    [SerializeField]
    protected float maxExp = 100;
    protected float curExp = 0;

    [SerializeField]
    protected float maxLevel = 10;
    protected float curLevel = 1;

    [SerializeField]
    protected float str;
   
    Animator animator;

    public UnityEvent Die;

    protected float moveSpeed;
    protected void Awake()
    {
        animator = GetComponentInChildren<Animator>();    
    }
    protected void Start()
    {
        curHp = maxHp;
        curMp = maxMp;
        animator.SetFloat("CurHp", curHp);
    }

    private void Update()
    {
        if (curHp <= 0)
            Die?.Invoke();
    }
    protected abstract void PlayerAttack();
}
