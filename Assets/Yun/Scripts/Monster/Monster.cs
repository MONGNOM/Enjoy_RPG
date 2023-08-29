using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public enum State
    {
        Idle,
        Trace,
        Return,
        Attack,
        Patrol,

        Size
    }

    protected State curState;
}
