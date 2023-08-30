using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<TOwner> where TOwner : class
{
    private TOwner owner;
    private State<TOwner> curState;
    private State<TOwner> preState;

    public void Init(TOwner owner, State<TOwner> state)
    {
        this.owner = owner;
        curState = null;
        preState = null;

        ChangeState(state);
    }

    public void Update()
    {
        if (curState == null)
        {
            return;
        }

        curState.Update(owner);
    }

    public void ChangeState(State<TOwner> state)
    {
        if (state == null)
        {
            return;
        }

        if (curState != null)
        {
            preState = curState;
            curState.Exit(owner);
        }

        curState = state;
        curState.Enter(owner);
    }

    public void ChangePreState()
    {
        if (preState == null)
        {
            return;
        }

        ChangeState(preState);
    }
}