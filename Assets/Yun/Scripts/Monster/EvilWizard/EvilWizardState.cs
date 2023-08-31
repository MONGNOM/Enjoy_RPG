using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EWStates
{
    public class EWIdle : State<Monster>
    {
        private Transform target;
        private float traceRange;
   
        public override void Enter(Monster owner)
        {
            target = owner.target.transform;
            traceRange = owner.traceRange;
        }

        public override void Update(Monster owner)
        {
            if ((target.position - owner.transform.position).sqrMagnitude < traceRange * traceRange)
            {
                owner.ChangeState(owner.state[Monster.State.Move]);
            }
        }

        public override void Exit(Monster owner)
        {
        }
    }

    public class EWMove : State<Monster>
    {
        private Transform target;
        private float traceRange;
        private float moveSpeed;

        public override void Enter(Monster owner)
        {
            target = owner.target.transform;
            traceRange = owner.traceRange;
            moveSpeed = owner.moveSpeed;
            owner.StartCoroutine(Attack(owner));
        }

        public override void Update(Monster owner)
        {
            Vector2 dir = (target.position - owner.transform.position).normalized;
            owner.rigid.velocity = dir * moveSpeed;
            owner.render.flipX = owner.rigid.velocity.x > 0 ? false : true;
            owner.anim.SetFloat("XSpeed", owner.rigid.velocity.y);
        }

        public override void Exit(Monster owner)
        {
        }

        private IEnumerator Attack(Monster owner)
        {
            yield return new WaitForSeconds(1.0f);

            if ((target.position - owner.transform.position).sqrMagnitude < traceRange * traceRange)
            {
                owner.ChangeState(owner.state[Monster.State.Idle]);
            }
        }
    }

    public class EWAttack : State<Monster>
    {
        public override void Enter(Monster owner)
        {
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
        }

        public override void Update(Monster owner)
        {
        }

        public override void Exit(Monster owner)
        {
        }
    }

    public class EWDeath : State<Monster>
    {
        public override void Enter(Monster owner)
        {
        }
        
        public override void Update(Monster owner)
        {
        }

        public override void Exit(Monster owner)
        {
        }
    }
}