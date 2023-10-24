using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Events;
using UnityEngine.UI;

public class Wizard : MonoBehaviour
{
    [Header("À§ÀÚµå½ºÅÈ")]
    [SerializeField, Range(0, 10000)]private float maxHp;
    [SerializeField, Range(1, 1000)] private float damage;
    [SerializeField] private Transform eyePosition;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private RectTransform hpbarPos;
    [SerializeField] private Image hpbar;
    [SerializeField] private TextMeshProUGUI damageText;
    [HideInInspector] public float curHp;
    public Animator wizardAnim;
    public UnityEvent death;
    public UnityEvent portalOn;
    public UnityEvent portalOff;
    private CapsuleCollider2D capsule;
    private BoxCollider2D box;
    public float damageWarrior;

    

    public float Damage 
    { get => damage; private set => damage = value; }

    private void Awake()
    {
        capsule = GetComponent<CapsuleCollider2D>();
        wizardAnim = GetComponentInChildren<Animator>();
        box = GetComponent<BoxCollider2D>();
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
        int damageint = Mathf.RoundToInt(damage);
        damageText.text = damageint.ToString();
        wizardAnim.SetTrigger("TakeHit");
        Instantiate(damageText,hpbarPos);
    }

    public void WizardResurrection()
    {
        wizardAnim.ResetTrigger("TakeHit");
        wizardAnim.SetBool("Death", false);
        capsule.enabled = true;
        //hpbarPos.gameObject.SetActive(true);
        maxHp *= 2.5f;
        curHp = maxHp;
        damage *= 1.5f;
        portalOff?.Invoke();
    }

    private void Turn()
    {
        transform.Rotate(Vector3.up, 180);
    }

    public void WizardDeath()
    {
        wizardAnim.SetBool("Death", true);
        capsule.enabled = false;
        box.enabled = false;
        ///hpbarPos.gameObject.SetActive(false);
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
