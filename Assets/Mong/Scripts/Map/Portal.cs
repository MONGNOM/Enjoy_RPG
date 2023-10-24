using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Portal : MonoBehaviour
{
    public UnityEvent portal;
    public Transform transformPos;
    public Transform monsterformPos;



    public void PortalPosition()
    {
        Warrior player = FindObjectOfType<Warrior>();
        if (player.curLevel >= 5 || player.Death)
        player.transform.position = transformPos.transform.position;
        else
        player.transform.position = monsterformPos.transform.position;

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            portal?.Invoke();
        }
    }

}
