using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class PlayerInfo : MonoBehaviour
{
    [SerializeField]
    protected float maxHp;
    protected float curHp;

    [SerializeField]
    protected float maxMp;
    protected float curMp;

    [SerializeField]
    protected float maxExp = 100;
    protected float curExp = 0;

    [SerializeField]
    protected float maxLevel = 10;
    protected float curLevel = 1;

    [SerializeField]
    protected float damage;

    protected float moveSpeed;
    private void Awake()
    {
        curHp = maxHp;
        curMp = maxMp;
    }

    protected abstract void PlayerAttack();
}
