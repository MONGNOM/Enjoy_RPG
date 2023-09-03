using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class outSlot : MonoBehaviour
{


    public SkillData skilldata;

    [SerializeField]
    private Image icon;


    public void OntEquipSkill()
    {
        if (!skilldata)
        {
            Debug.Log("스킬이 없습니다");
            return;
        }
        else
        {

            skilldata = SkillManager.Instance.skillData;
            icon.sprite = SkillManager.Instance.skillData.icon;

        }
    }
    public void OntEquipSkill2()
    {
        if (!skilldata)
        {
            Debug.Log("스킬이 없습니다");
            return;
        }
        else
        {

            skilldata = SkillManager.Instance.skillimpactData;
            icon.sprite = SkillManager.Instance.skillimpactData.icon;

        }
    }

    public void UseSkill()
    {

        
    }
}
