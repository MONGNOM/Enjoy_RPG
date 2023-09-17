using UnityEngine;

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
    public string itemName;
    public Sprite image;
    public bool isStackable = true;
    public int itemCost;
    public float itemAbilityValue;
}
