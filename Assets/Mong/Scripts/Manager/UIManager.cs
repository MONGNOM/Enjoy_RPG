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






    // Start is called before the first frame update
    void Start()
    {
        warrior = FindObjectOfType<Warrior>();
    }

    // Update is called once per frame
    void Update()
    {
        expbar.fillAmount = warrior.curExp / warrior.maxExp;
        level.text = warrior.curLevel.ToString();
        exp.text = warrior.curExp.ToString();
        hpbar.fillAmount = warrior.curMp / warrior.maxMp;
        hpbar.fillAmount = warrior.curHp / warrior.maxHp;
    }
}
