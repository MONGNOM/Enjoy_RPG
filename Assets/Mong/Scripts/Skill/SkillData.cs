using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "스킬/스킬")]
public class SkillData : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite icon;
    public float damageup;
    public float damage;
}
