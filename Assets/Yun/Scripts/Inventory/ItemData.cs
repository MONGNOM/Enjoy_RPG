using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Item")]
public class ItemData : ScriptableObject
{
    public new string name;
    public string description;
    public GameObject prefab;
    public Sprite icon;
}