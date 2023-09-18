using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Events;

public class Wizard : MonoBehaviour
{
    [Header("À§ÀÚµå½ºÅÈ")]
    [SerializeField, Range(0, 100)]private float maxHp;
    [SerializeField, Range(1, 100)] private float damage;
    [SerializeField] private Transform eyePosition;
    [SerializeField] private LayerMask layerMask;
    [HideInInspector] public float curHp;
    private Animator wizardAnim;
    public UnityEvent death;

    public float Damage 
    { get => damage; private set => damage = value; }

    private void Awake()
    {
        wizardAnim = GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        curHp = maxHp;    
    }

    private void FixedUpdate()
    {
        GroundCheck();
    }

    private void Update()
    {
        if (curHp <= 0)
        {
            death?.Invoke();
        }
    }

    private void GroundCheck()
    {
        Vector2 origin = eyePosition.position;
        RaycastHit2D hit = Physics2D.Raycast(origin, eyePosition.up, 4f, layerMask);
        Debug.DrawRay(origin, eyePosition.up * hit.distance, new Color(1, 0, 0));
        if (hit.collider == null)
        {
            Turn();
        }
    }

    private void Turn()
    {
        transform.Rotate(Vector3.up, 180);
    }

    public void WizardDeath()
    {
        wizardAnim.SetBool("Death", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            wizardAnim.SetTrigger("TakeHit");
        }
    }
}
