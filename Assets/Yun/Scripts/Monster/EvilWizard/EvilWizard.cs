using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilWizard : Monster
{
    protected override void Awake()
    {
        base.Awake();

        state = new Dictionary<State, State<Monster>>();
        state.Add(State.Idle, new EWStates.EWIdle());
        state.Add(State.Move, new EWStates.EWMove());
        state.Add(State.Attack, new EWStates.EWAttack());
        state.Add(State.TakeHit, new EWStates.EWTakeHIt());
        state.Add(State.Death, new EWStates.EWDeath());

        stateMachine = new StateMachine<Monster>();
        stateMachine.Init(this, state[State.Idle]);
    }

    private void Start()
    {
    }

    private void Update()
    {
        stateMachine.Update();
    }
}
