using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilWizard : Monster
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Transform sight;
    [SerializeField]
    private LayerMask layerMask;

    private Rigidbody2D rigid;
    private Animator animator;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        if (!IsGroundCheck())
        {
            Turn();
        }
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        rigid.velocity = new Vector2(transform.right.x, rigid.velocity.y);
    }
   
    public void Turn()
    {
        transform.Rotate(Vector3.up, 180.0f);
    }
    
    private bool IsGroundCheck()
    {
        Debug.DrawRay(sight.position, Vector2.down, Color.red);
        return Physics2D.Raycast(sight.position, Vector2.down, 1.0f, layerMask);
    }
}
