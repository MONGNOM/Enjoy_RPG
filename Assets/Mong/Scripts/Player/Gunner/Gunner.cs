using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Gunner : MonoBehaviour
{
    private Animator gunnerAnim;
    public PlayerController player;
    public UnityEvent Guninter;

    [SerializeField]
    private Bullet bulletprefab;
    [SerializeField]
    private Transform bulletStartTransform;

   

    private void Awake()
    {
        player = GetComponent<PlayerController>();
        gunnerAnim = GetComponentInChildren<Animator>();  
    }

    void Start()
    {
    }


    public void Die()
    {
        gunnerAnim.SetTrigger("Die");
    }

    private void OnAttack(InputValue value)
    {
        if (!player.interaction)
        {
            if (!gunnerAnim.GetBool("Grounded")|| player.XSpeed >= 0.1)
            {
                gunnerAnim.ResetTrigger("Attack");
            }
            else
            {
                gunnerAnim.SetTrigger("Attack");
                Debug.Log("111");
                Instantiate(bulletprefab,bulletStartTransform);
            }
        }
        else
        {
            //창고창 열어주기 매서드
            Guninter?.Invoke();
        }

    }

    private void OnSkill(InputValue value)
    {
        if (!SkillManager.Instance.outslots[0].skilldata)
            return;

        //스킬사용매서드 
        gunnerAnim.SetTrigger("PowerUp");
    }

    private void OnSkill2(InputValue value)
    {
        //스킬사용매서드
        if (!SkillManager.Instance.outslots[1].skilldata)
            return;

        gunnerAnim.SetTrigger("PowerStrike");
    }
}
