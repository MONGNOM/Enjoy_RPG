using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DieUI : MonoBehaviour
{
    Warrior warrior;
    public UnityEvent openUi;

    private void Awake()
    {
        warrior = FindObjectOfType<Warrior>();
    }
    






}
