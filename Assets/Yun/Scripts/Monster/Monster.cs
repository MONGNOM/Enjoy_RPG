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

    public Dictionary<State, State<Monster>> state;
    protected StateMachine<Monster> stateMachine;

    protected Rigidbody2D rigid;
    protected Collider2D coll;
    protected SpriteRenderer render;
    public Animator anim;

    protected float range;
    protected float moveSpeed;
    protected GameObject target;

    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        stateMachine.Update();
    }

    protected abstract void Attack();

    protected abstract void Die();

    public void ChangeState(State<Monster> state)
    {
        stateMachine.ChangeState(state);
    }

    public void ChangePreState()
    {
        stateMachine.ChangePreState();
    }
}
