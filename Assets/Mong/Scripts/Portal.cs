using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Portal : MonoBehaviour
{
    public UnityEvent homePortal;
    public UnityEvent MonsterPortal;
    
    public Transform MonstertransformPos;
    public Transform HometransformPos;

    public bool home;
    PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }
    public void MonsterMapPosition()
    {
        home = true;
        player.transform.position = MonstertransformPos.transform.position;
    }
    public void HomeMapPosition()
    {
        home = false;
        player.transform.position = HometransformPos.transform.position;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            if (home)
            homePortal?.Invoke();
            else
            MonsterPortal?.Invoke();
        }
    }

}
