using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUi : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }
    public void OpenSkilUiButton()
    {
        gameObject.SetActive(true);
    }

    public void CloseSkilUiButton() 
    { 
        gameObject.SetActive(false);
    }
    void Update()
    {
        
    }
}
