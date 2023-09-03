using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "��ų/��ų")]
public class SkillData : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite icon;
    public float damageup;
    public float damage;
}
