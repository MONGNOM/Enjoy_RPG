using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilWizard : Monster
{
    protected override void Awake()
    {
        base.Awake();
        target = GameObject.FindWithTag("Player");

        state = new Dictionary<State, State<Monster>>();
        state.Add(State.Idle, new EWStates.EWIdle());
        state.Add(State.Idle, new EWStates.EWMove());
        state.Add(State.Idle, new EWStates.EWAttack());
        state.Add(State.Idle, new EWStates.EWTakeHIt());
        state.Add(State.Idle, new EWStates.EWDeath());

        stateMachine = new StateMachine<Monster>();
        stateMachine.Init(this, state[State.Idle]);
    }

    protected override void Attack()
    {

    }


    protected override void Die()
    {

    }
}
