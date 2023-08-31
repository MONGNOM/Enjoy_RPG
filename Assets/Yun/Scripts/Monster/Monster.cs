using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    public enum State
    {
        Idle,
        Move,
        Attack,
        TakeHit,
        Death,

        Size
    }

    public Animator anim;
    public Rigidbody2D rigid;
    public Collider2D coll;
    public SpriteRenderer render;
    public GameObject target;
    public float traceRange;
    public float attackRange;
    public float moveSpeed;
    public float hitReturnTime;
    public float deathTime;

    public Dictionary<State, State<Monster>> state;
    public StateMachine<Monster> stateMachine;

    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponentInChildren<Animator>();
        render = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        stateMachine.Update();
    }

    public void ChangeState(State<Monster> state)
    {
        stateMachine.ChangeState(state);
    }

    public void ChangePreState()
    {
        stateMachine.ChangePreState();
    }
}
