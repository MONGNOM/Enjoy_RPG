using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillManager : SingleTon<SkillManager>
{
    

    public SkillData skillData;
    public SkillData skillimpactData;
    public SkillSlot slot;

    [SerializeField]
    private SkillUi skillUI;

    [SerializeField]
    private TextMeshProUGUI buffskillname;

    [SerializeField]
    private TextMeshProUGUI impactskillname;


    public List<EquipSkill> skils = new List<EquipSkill>();

    public List<SkillSlot> slots = new List<SkillSlot>();

    public List<outSlot> outslots = new List<outSlot>();

    private void Awake()
    {
    }
    void Start()
    {
        EquipSkill skill = new EquipSkill();
        skill.skillData = skillData;
        buffskillname.text = skill.skillData.name;
        skils.Add(skill);

        EquipSkill skillimpact = new EquipSkill();
        skillimpact.skillData = skillimpactData;
        impactskillname.text = skillimpact.skillData.name;
        skils.Add(skillimpact);
    }



    public void SkillEquip()
    {
            // 스킬데이터를 넘겨줄때 뭘로 넘겨줘야하나
            slots[0].skilldata = skils[0].skillData;
        outslots[0].skilldata = skils[0].skillData;

        skillUI.UpdateUI();
      
    }
    public void SkillEquip2()
    {
            // 스킬데이터를 넘겨줄때 뭘로 넘겨줘야하나
        slots[1].skilldata = skils[1].skillData;
        outslots[1].skilldata = skils[1].skillData;
        skillUI.UpdateUI();

    }

    public void OpenSkillTree()
    {
        skillUI.gameObject.SetActive(true);

    }
    public void CloseSkillTree()
    {
        skillUI.gameObject.SetActive(false);
    }



    
}
