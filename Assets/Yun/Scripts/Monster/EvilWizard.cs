using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilWizard : Monster
{
    private StateMachine<State, EvilWizard> stateMachine;

    protected override void Awake()
    {
        base.Awake();

        stateMachine = new StateMachine<State, EvilWizard>(this);
        stateMachine.AddState(State.Idle, new EWIdleState(this, stateMachine));
        stateMachine.AddState(State.Move, new EWMoveState(this, stateMachine));
        stateMachine.AddState(State.Attack, new EWAttackState(this, stateMachine));
        stateMachine.AddState(State.TakeHit, new EWIdleState(this, stateMachine));
        stateMachine.AddState(State.Death, new EWIdleState(this, stateMachine));
    }

    private void Start()
    {
        stateMachine.Init(State.Idle);
    }

    private void Update()
    {
        stateMachine.Update();
    }

    protected override void Die()
    {
        stateMachine.ChangeState(State.Death);
    }

    private abstract class EvilWizardState : StateBase<State, EvilWizard>
    {
        protected EvilWizardState(EvilWizard owner, StateMachine<State, EvilWizard> stateMachine) : base(owner, stateMachine)
        {
        }

        protected GameObject gameObject => owner.gameObject;
        protected Transform transform => owner.transform;
        protected Rigidbody2D rigidbody => owner.rigidbody;
        protected SpriteRenderer renderer => owner.renderer;
        protected Animator animator => owner.animator;
        protected Collider2D collider => owner.collider;
    }

    private class EWIdleState : EvilWizardState
    {
        private Transform target;
        private float range;

        public EWIdleState(EvilWizard owner, StateMachine<State, EvilWizard> stateMachine) : base(owner, stateMachine)
        {
        }

        public override void Init()
        {
            target = owner.targetPos;
            range = owner.range;
        }

        public override void Enter()
        {
        }

        public override void Transition()
        {
        }

        public override void Update()
        {
        }

        public override void Exit()
        {
        }
    }

    private class EWMoveState : EvilWizardState
    {
        public EWMoveState(EvilWizard owner, StateMachine<State, EvilWizard> stateMachine) : base(owner, stateMachine)
        {
        }

        public override void Init()
        {
        }

        public override void Enter()
        {
        }

        public override void Update()
        {
        }

        public override void Transition()
        {
        }

        public override void Exit()
        {
        }
    }

    private class EWAttackState : EvilWizardState
    {
        public EWAttackState(EvilWizard owner, StateMachine<State, EvilWizard> stateMachine) : base(owner, stateMachine)
        {
        }

        public override void Init()
        {
        }

        public override void Enter()
        {
        }

        public override void Update()
        {
        }

        public override void Transition()
        {
        }

        public override void Exit()
        {
        }
    }

    private class EWTakeHitState : EvilWizardState
    {
        public EWTakeHitState(EvilWizard owner, StateMachine<State, EvilWizard> stateMachine) : base(owner, stateMachine)
        {
        }

        public override void Init()
        {
        }

        public override void Enter()
        {
        }

        public override void Update()
        {
        }

        public override void Transition()
        {
        }

        public override void Exit()
        {
        }
    }

    private class EWDeathState : EvilWizardState
    {
        public EWDeathState(EvilWizard owner, StateMachine<State, EvilWizard> stateMachine) : base(owner, stateMachine)
        {
        }

        public override void Init()
        {
        }

        public override void Enter()
        {
        }

        public override void Update()
        {
        }

        public override void Transition()
        {
        }

        public override void Exit()
        {
        }
    }
}
