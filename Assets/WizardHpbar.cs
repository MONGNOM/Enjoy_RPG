using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardHpbar : MonoBehaviour
{
    [SerializeField]
    private Wizard wizard;
   

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(wizard.transform.position + Vector3.up);
    }
}
