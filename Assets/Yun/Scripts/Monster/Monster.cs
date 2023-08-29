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

    protected State curState;

    protected new Rigidbody2D rigidbody;
    protected new Collider2D collider;
    protected new SpriteRenderer renderer;
    protected Animator animator;

    protected float range;
    protected float moveSpeed;
    protected Transform targetPos;

    protected virtual void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    protected abstract void Die();
}
