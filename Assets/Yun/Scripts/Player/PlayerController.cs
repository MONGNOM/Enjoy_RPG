using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    private PlayerInput playerInput;
    private Rigidbody2D rigid;
    private Animator anim;
    private SpriteRenderer render;
    [SerializeField]
    private GameObject sword;

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
        anim = GetComponentInChildren<Animator>();
        render = GetComponentInChildren<SpriteRenderer>();
        playerInput = GetComponent<PlayerInput>();
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
            Debug.Log("움직임감지");
            Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();
            rigid.velocity = new Vector2(input.x * moveSpeed * Time.deltaTime, rigid.velocity.y);
    }

    private void Jump()
    {
        if (playerInput.actions["Jump"].triggered &&Grounded)
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
            sword.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        else if (rigid.velocity.x < 0)
        {
            render.flipX = true;
            sword.transform.rotation = Quaternion.Euler(0f, 180f, 0f);


        }
    }
}
