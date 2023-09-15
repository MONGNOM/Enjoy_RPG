using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : SingleTon<ShopManager>
{

    [Header("Item")]
    [SerializeField] private GameObject shopGroup;
    [SerializeField] private Item[] sellingItems;
    [SerializeField] private ShopItemSlot[] shopItemSlots;
    [SerializeField] private GameObject[] shopItemSlotObjects;
    [SerializeField] private Button[] purchaseButtons;

    [Header("Coin")]
    [SerializeField] private int coins;
    [SerializeField] private TextMeshProUGUI coinUI;

    private void Start()
    {
        for (int i = 0; i < shopItemSlots.Length; i++)
        {
            shopItemSlotObjects[i].SetActive(true);
        }

        UpdateCoin();
        UpdateItemData();
        UpdatePurchaseButton();
    }

    public void UpdateCoin()
    {
        coinUI.text = $"{coins}";
    }

    public void UpdateItemData()
    {
        for (int i = 0; i < sellingItems.Length; i++)
        {
            shopItemSlots[i].itemImage.sprite = sellingItems[i].image;
            shopItemSlots[i].itemName.text = sellingItems[i].itemName;
            shopItemSlots[i].itemCost.text = sellingItems[i].itemCost.ToString();
        }
    }

    public void UpdatePurchaseButton()
    {
        for (int i = 0; i < sellingItems.Length; i++)
        {
            if (coins >= sellingItems[i].itemCost)
                purchaseButtons[i].interactable = true;
            else
                purchaseButtons[i].interactable = false;
        }
    }

    public void UpdatePurchaseItem(int button)
    {
        if (coins >= sellingItems[button].itemCost)
        {
            coins -= sellingItems[button].itemCost;
            InventoryManager.Instance.AddItem(sellingItems[button]);
            UpdateCoin();
            UpdatePurchaseButton();
        }
    }

    public void OnClickOpenShopButton()
    {
        shopGroup.SetActive(true);
    }

    public void OnClickCloseShopButton()
    {
        shopGroup.SetActive(false);
    }
}
