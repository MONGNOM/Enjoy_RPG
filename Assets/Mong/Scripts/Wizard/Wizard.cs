using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wizard : MonoBehaviour
{
    [SerializeField, Range(0, 100)]
    private float maxHp;
    private float curHp;

    private Animator wizardAnim;

    public UnityEvent death;


    private void Awake()
    {
        wizardAnim = GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        curHp = maxHp;    
    }

    private void Update()
    {
        if (curHp <= 0)
        {
            death?.Invoke();
        }
    }

    public void WizardDeath()
    {
        wizardAnim.SetBool("Death", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            Debug.Log("공격받음");
            wizardAnim.SetTrigger("TakeHit");
        }
    }
}
