using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum ItemType
{
    Weapon,
    Consumable,

    Size,
}

[CreateAssetMenu(menuName = "Scriptable Object/Item")]
public class Item : ScriptableObject
{
    [Header("Common")]
    public ItemType type;
    public Sprite image;
    public bool isStackable = true;

    [Header("Only Shop")]
    public int cost;
}
