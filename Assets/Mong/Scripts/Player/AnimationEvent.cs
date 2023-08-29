using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEvent : MonoBehaviour
{
    public UnityEvent onAttackStart;
    public UnityEvent onAttackEnd;

    public void OnAttackStart()
    { 
        onAttackStart?.Invoke();
    }
    public void OnAttackEnd()
    { 
        onAttackEnd?.Invoke();
    }


}
