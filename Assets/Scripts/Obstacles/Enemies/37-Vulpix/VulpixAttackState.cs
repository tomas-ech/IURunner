using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VulpixAttackState : EnemyState
{
    private EnemyVulpix enemyVulpix;

    public VulpixAttackState(EnemyStateMachine _stateMachine, Enemy _enemy, string _animBoolName, EnemyVulpix _enemyVulpix) : base(_stateMachine, _enemy, _animBoolName)
    {
        this.enemyVulpix = _enemyVulpix;
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = enemyVulpix.attackTime;
    }
    public override void Update()
    {
        base.Update();

        if (!enemyVulpix.IsPlayerDetected() && stateTimer < 0)
        {
            stateMachine.ChangeState(enemyVulpix.idleState);
        }

    }

    public override void Exit()
    {
        base.Exit();
    }
}
