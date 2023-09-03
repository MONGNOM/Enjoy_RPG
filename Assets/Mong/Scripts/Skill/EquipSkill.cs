using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSkill : MonoBehaviour
{
    public SkillData skillData;

    public virtual void Use()
    {
        //스킬 사용 매서드
        Debug.Log("스킬을 사용합니다");
    }
}
