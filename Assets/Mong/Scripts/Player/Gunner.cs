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
            //â��â �����ֱ� �ż���
            Guninter?.Invoke();
        }

    }

    private void OnSkill(InputValue value)
    {
        if (!SkillManager.Instance.outslots[0].skilldata)
            return;

        //��ų���ż��� 
        gunnerAnim.SetTrigger("PowerUp");
    }

    private void OnSkill2(InputValue value)
    {
        //��ų���ż���
        if (!SkillManager.Instance.outslots[1].skilldata)
            return;

        gunnerAnim.SetTrigger("PowerStrike");
    }
}
