using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikachuIdleState : EnemyState
{
    private EnemyPikachu enemyPikachu;

    public PikachuIdleState(EnemyStateMachine _stateMachine, Enemy _enemy, string _animBoolName, EnemyPikachu _enemyPikachu) : base(_stateMachine, _enemy, _animBoolName)
    {
        this.enemyPikachu = _enemyPikachu;
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = enemyPikachu.idleTime;
    }
    public override void Update()
    {
        base.Update();

        if (stateTimer < 0f)
        {
            stateMachine.ChangeState(enemyPikachu.moveState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

}
