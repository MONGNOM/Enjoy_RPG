using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Mushroom : MonoBehaviour
{
    private Rigidbody2D rigid;
    private CapsuleCollider2D capsuleCollider;
    private Animator animator;

    [SerializeField] private float hp;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform sight;
    [SerializeField] private LayerMask layerMask;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        GroundCheck();    
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        rigid.velocity = new Vector2(transform.right.x * moveSpeed, rigid.velocity.y);
    }

    private void GroundCheck()
    {
        Vector2 origin = sight.position;
        RaycastHit2D hit = Physics2D.Raycast(origin, sight.up, 3f, layerMask);
        Debug.DrawRay(origin, sight.up * hit.distance, new Color(1, 0, 0));

        if (null == hit.collider)
        {
            Turn();
        }
    }

    private void Turn()
    {
        transform.Rotate(Vector3.up, 180);
        sight.Rotate(Vector3.up, 180);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            animator.SetTrigger("Hitted");
        }
    }
}