using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackColider : MonoBehaviour
{
    public new BoxCollider2D collider2D;
    [SerializeField]
    private Warrior warrior;

    private void Awake()
    {
        collider2D = GetComponent<BoxCollider2D>();
        collider2D.enabled = false;
        warrior = GetComponentInParent<Warrior>();
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
            Wizard wizard = null;
            collision.gameObject.TryGetComponent<Wizard>(out wizard);
            if (wizard == null)
                return;
            else
            {
                wizard.Takehit(warrior.Attackdamage());
            }
        }
    }
}
