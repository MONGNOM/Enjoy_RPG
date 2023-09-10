using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipMentWindow : MonoBehaviour
{
    public void EquipMentWindowopen()
    { 
        gameObject.SetActive(true);
    }
    public void EquipMentWindowClose()
    {
        gameObject.SetActive(false);
    }
}
