using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Animator anim;
    private SpriteRenderer render;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask layerMask;
    
    private float XSpeed
    {
        get { return anim.GetFloat("XSpeed"); }
        set { anim.SetFloat("XSpeed", value); }
    }

    private float YSpeed
    {
        get { return anim.GetFloat("YSpeed"); }
        set { anim.SetFloat("YSpeed", value); }
    }

    private bool Grounded
    {
        get { return anim.GetBool("Grounded"); }
        set { anim.SetBool("Grounded", value); }
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        GroundCheck();
    }

    private void Update()
    {
        Move();
        Jump();

        UpdateAnimator();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            Grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Grounded = false;
    }

    private void Move()
    {
        rigid.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rigid.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    private void GroundCheck()
    {
        Vector2 origin = new Vector2(transform.position.x, transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, 1.5f, layerMask);
        Debug.DrawRay(origin, Vector2.down * 1.5f, new Color(0, 0, 1));

        if (null != hit.collider)
            Grounded = true;
        else
            Grounded = false;
    }

    private void UpdateAnimator()
    {
        XSpeed = Mathf.Abs(rigid.velocity.x);
        YSpeed = rigid.velocity.y;

        if (rigid.velocity.x > 0)
        {
            render.flipX = false;
        }

        else if (rigid.velocity.x < 0)
        {
            render.flipX = true;
        }
    }
}
