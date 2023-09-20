using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float destroyTime;
    
    private void Start()
    {
        StartCoroutine(DestroyText());
    }
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
    }
    IEnumerator DestroyText()
    {
       yield return new WaitForSeconds(destroyTime);
       Destroy(gameObject);
    }
}
