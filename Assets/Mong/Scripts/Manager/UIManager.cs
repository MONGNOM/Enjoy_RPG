using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingleTon<UIManager>
{
    [SerializeField]
    private TextMeshProUGUI level;

    [SerializeField]
    private Warrior warrior;

    [SerializeField]
    private Image expbar;

    [SerializeField]
    private Image hpbar;

    [SerializeField]
    private Image mpbar;

    [SerializeField]
    private TextMeshProUGUI exp;

    [SerializeField]
    private float curexpText;
    [SerializeField]
    private string percentText;






    // Start is called before the first frame update
    void Start()
    {
        warrior = FindObjectOfType<Warrior>();
    }

    // Update is called once per frame
    void Update()
    {
        curexpText = warrior.curExp / warrior.maxExp *100;
        expbar.fillAmount = warrior.curExp / warrior.maxExp;
        level.text = warrior.curLevel.ToString();
        exp.text = string.Format("{0}{1}", curexpText.ToString(), percentText.ToString());
        mpbar.fillAmount = warrior.curMp / warrior.maxMp;
        hpbar.fillAmount = warrior.curHp / warrior.maxHp;
    }
}
