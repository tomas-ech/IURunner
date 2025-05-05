using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PidgeyIdleState : EnemyState
{
    private EnemyPidgey enemyPidgey;

    public PidgeyIdleState(EnemyStateMachine _stateMachine, Enemy _enemy, string _animBoolName, EnemyPidgey _enemyPidgey) : base(_stateMachine, _enemy, _animBoolName)
    {
        this.enemyPidgey = _enemyPidgey;
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = enemyPidgey.idleTime;
    }
    public override void Update()
    {
        base.Update();

        if (stateTimer < 0f)
        {
            stateMachine.ChangeState(enemyPidgey.moveState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
