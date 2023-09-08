using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public PlayerController controller;
    [SerializeField]
    private float bulletSpeed;


    // 코루틴써서 시간초 지나면 사라지게 ㄱ 
    private void Awake()
    {
        controller = FindObjectOfType<PlayerController>();
    }
    private void Update()
    {
        // 방향 수정하면 끝
        transform.Translate(controller.bulletShooter.transform.right * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            Debug.Log("몬스터를 공격했다");
            Destroy(gameObject);
        }
    }
}
