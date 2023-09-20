using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Events;
using UnityEngine.UI;

public class Wizard : MonoBehaviour
{
    [Header("À§ÀÚµå½ºÅÈ")]
    [SerializeField, Range(0, 100000)]private float maxHp;
    [SerializeField, Range(1, 100)] private float damage;
    [SerializeField] private Transform eyePosition;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private RectTransform hpbarPos;
    [SerializeField] private Image hpbar;
    [HideInInspector] public float curHp;
    public Animator wizardAnim;
    public UnityEvent death;
    public UnityEvent portalOn;
    private CapsuleCollider2D capsule;
    public float damageWarrior;

    

    public float Damage 
    { get => damage; private set => damage = value; }

    private void Awake()
    {
        capsule = GetComponent<CapsuleCollider2D>();
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
        hpbarPos.transform.position = transform.position;
        hpbar.fillAmount = curHp / maxHp;

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

    public void Takehit(float damage)
    {
        damageWarrior = damage;
        wizardAnim.SetTrigger("TakeHit");
        Debug.Log(damage);
    }

    private void Turn()
    {
        transform.Rotate(Vector3.up, 180);
    }

    public void WizardDeath()
    {
        wizardAnim.SetBool("Death", true);
        capsule.enabled = false;
        hpbarPos.gameObject.SetActive(false);
        portalOn?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (wizardAnim.GetBool("Death"))
                return;

            Warrior warrior = null;
            collision.gameObject.TryGetComponent<Warrior>(out warrior);
            if (warrior == null)
                return;
            else
            {
                warrior.TakeHit(damage);
            }
        }
    }
}
