using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUi : MonoBehaviour
{
    public SkillSlot[] skillSlots;

    public void UpdateUI()
    { 
        skillSlots = GetComponentsInChildren<SkillSlot>();

        for (int i = 0; i < skillSlots.Length; ++i)
        {
            if (i < SkillManager.Instance.skils.Count)
            {
                skillSlots[i].EquipSkill(SkillManager.Instance.skils[i]);
            }
            else 
            {
                skillSlots[i].UnEquipSkill();
            }
        }
    }
}
