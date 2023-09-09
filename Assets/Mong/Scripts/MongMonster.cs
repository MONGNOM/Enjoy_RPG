using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MongMonster : MonoBehaviour
{
    public float Hp;
    public float giveExp;
    public Warrior warrior;

    private void Start()
    {
        warrior =FindObjectOfType<Warrior>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Hp -= 10;
            Destroy(gameObject);
            warrior.curExp += giveExp;

        }
    }
}
