using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : SingleTon<ShopManager>
{
    public int coins;
    public TextMeshProUGUI coinUI;
    
    public void UpdateCoin()
    {
        coinUI.text = $": {coins}";
    }
}
