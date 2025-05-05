using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VulpixIdleState : EnemyState
{
    private EnemyVulpix enemyVulpix;

    public VulpixIdleState(EnemyStateMachine _stateMachine, Enemy _enemy, string _animBoolName, EnemyVulpix _enemyVulpix) : base(_stateMachine, _enemy, _animBoolName)
    {
        this.enemyVulpix = _enemyVulpix;
    }

    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        base.Update();

        if (enemyVulpix.IsPlayerDetected())
        {
            stateMachine.ChangeState(enemyVulpix.attackState);
        }

    }

    public override void Exit()
    {
        base.Exit();
    }
}
