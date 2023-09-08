using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackColider : MonoBehaviour
{
    public new BoxCollider2D collider2D;
   

    private void Awake()
    {
        collider2D = GetComponent<BoxCollider2D>();
        collider2D.enabled = false;

    }
    public void AttackColiderEnable()
    {
        collider2D.enabled = true;
    }
    public void AttackColiderDisable()
    {
        collider2D.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            Debug.Log("몬스터를 공격했다");
        }
    }
}
