using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : PlayerInfo
{
    protected override void PlayerAttack()
    {
        Debug.Log("근접공격");
    }
}
