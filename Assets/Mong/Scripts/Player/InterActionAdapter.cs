using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InterActionAdapter : MonoBehaviour, IInteratable
{
    public UnityEvent<PlayerController> interAction;
    public void InterAction(PlayerController player)
    {
        interAction?.Invoke(player);
    }

   
}
