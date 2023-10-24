using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButtonController : MonoBehaviour
{
    private Button button;

    // Start is called before the first frame update
    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void Buttoninterctible()
    { 
        Warrior warrior = FindObjectOfType<Warrior>();

        if (warrior.curLevel < 5)
        button.interactable = false;
        else
        button.interactable = true;
    }

}
