using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EWStates
{
    public class EWIdle : State<Monster>
    {
        public override void Enter(Monster owner)
        {
            owner.anim.SetTrigger("Idle");
        }

        public override void Update(Monster owner)
        {
            owner.ChangeState(owner.state[Monster.State.Move]);
        }

        public override void Exit(Monster owner)
        {
        }
    }

    public class EWMove : State<Monster>
    {
        public override void Enter(Monster owner)
        {
            owner.anim.SetTrigger("Move");
        }

        public override void Update(Monster owner)
        {
            owner.ChangeState(owner.state[Monster.State.Idle]);
            owner.ChangeState(owner.state[Monster.State.Attack]);

        }

        public override void Exit(Monster owner)
        {
        }
    }

    public class EWAttack : State<Monster>
    {
        public override void Enter(Monster owner)
        {
            owner.anim.SetTrigger("Attack");
        }

        public override void Update(Monster owner)
        {
        }

        public override void Exit(Monster owner)
        {
        }
    }

    public class EWTakeHIt : State<Monster>
    {
        public override void Enter(Monster owner)
        {
            owner.anim.SetTrigger("TakeHit");
            owner.ChangeState(owner.state[Monster.State.Idle]);
        }

        public override void Exit(Monster owner)
        {
        }

        public override void Update(Monster owner)
        {
        }
    }

    public class EWDeath : State<Monster>
    {
        public override void Enter(Monster owner)
        {
            owner.anim.SetTrigger("Death");
        }

        public override void Exit(Monster owner)
        {
        }

        public override void Update(Monster owner)
        {
        }
    }
}