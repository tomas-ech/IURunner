using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikachuMoveState : EnemyState
{
    private EnemyPikachu enemyPikachu;
    private bool triggerAttack = false;

    public PikachuMoveState(EnemyStateMachine _stateMachine, Enemy _enemy, string _animBoolName, EnemyPikachu _enemyPikachu) : base(_stateMachine, _enemy, _animBoolName)
    {
        this.enemyPikachu = _enemyPikachu;
    }

    public override void Enter()
    {
        base.Enter();

        triggerAttack = RandomGenerator.GetRandomInt(0, 2) != 0;
        stateTimer = enemyPikachu.moveTime;
    }
    public override void Update()
    {
        base.Update();

        enemyPikachu.SetMovement(enemy.speed * enemyPikachu.currentDirection, enemyPikachu.rigidBody.velocity.y);

        if (stateTimer < 0)
        {
            stateMachine.ChangeState(triggerAttack ? enemyPikachu.attackState : enemyPikachu.idleState);
            return;
        }

        if (enemyPikachu.IsAtWall() || !enemyPikachu.IsOnGround())
        {
            enemyPikachu.ChangeDirection();
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
