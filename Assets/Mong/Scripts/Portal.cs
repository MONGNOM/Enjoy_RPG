using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Portal : MonoBehaviour
{
    public UnityEvent portal;
    public Transform transformPos;

   
    public void PortalPosition()
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        player.transform.position = transformPos.transform.position;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            portal?.Invoke();
        }
    }

}
