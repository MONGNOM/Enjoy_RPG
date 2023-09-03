using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour
{
    [SerializeField]
    private Button equipButton;

    public bool onEquip;

    public SkillData skilldata;


    [SerializeField]
    private Button useButton;

    
    [SerializeField]
    private Image equipCheck;

    [SerializeField]
    private Image icon;

    private void Start()
    {
        onEquip = false;
        equipCheck.gameObject.SetActive(false);
    }
    public void OnEquip()
    {
        onEquip = true;    
    }
    public void EquipSkill(EquipSkill equipSkill)
    {
        if (!onEquip)
        {
            Debug.Log("장착을 누르지않음");
            return; 
        }
        else
        {
            equipCheck.gameObject.SetActive(true);
            useButton.interactable = true;
            icon.sprite = equipSkill.skillData.icon;
            onEquip = false;
        }
    }

    public void UnEquipSkill()
    {
        // 스프라이트 아이콘이 그대로 돌아오게 해야함
        //equipCheck.gameObject.SetActive(false);
        //useButton.interactable = false;
        useButton.image = null;
    }

}


