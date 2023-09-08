using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public PlayerController controller;
    [SerializeField]
    private float bulletSpeed;


    // �ڷ�ƾ�Ἥ �ð��� ������ ������� �� 
    private void Awake()
    {
        controller = FindObjectOfType<PlayerController>();
    }
    private void Update()
    {
        // ���� �����ϸ� ��
        transform.Translate(controller.bulletShooter.transform.right * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            Debug.Log("���͸� �����ߴ�");
            Destroy(gameObject);
        }
    }
}
