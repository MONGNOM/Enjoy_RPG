using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public abstract class PlayerInfo : MonoBehaviour
{
    public float maxHp;
    public float curHp;

    public float maxMp;
    public float curMp;

    public float maxExp = 100;
    public float curExp = 0;

    public float maxLevel = 10;
    public float curLevel = 1;

    public float str;
   
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
