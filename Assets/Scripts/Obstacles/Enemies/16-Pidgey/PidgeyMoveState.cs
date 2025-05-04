using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PidgeyMoveState : EnemyState
{
    private EnemyPidgey enemyPidgey;
    private int index;

    public PidgeyMoveState(EnemyStateMachine _stateMachine, Enemy _enemy, string _animBoolName, EnemyPidgey _enemyPidgey) : base(_stateMachine, _enemy, _animBoolName)
    {
        this.enemyPidgey = _enemyPidgey;
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = enemyPidgey.moveTime;
    }
    public override void Update()
    {
        base.Update();

        if (stateTimer < 0f)
        {
            stateMachine.ChangeState(enemyPidgey.idleState);
        }


        enemyPidgey.transform.position = Vector3.MoveTowards(enemyPidgey.transform.position, enemyPidgey.pointsToMove[index].position, enemyPidgey.speed * Time.deltaTime);

        if (enemyPidgey.pointsToMove[index].localPosition.x <= enemyPidgey.transform.localPosition.x && enemyPidgey.currentDirection == 1)
        {
            enemyPidgey.ChangeDirection();
        }
        else if (enemyPidgey.pointsToMove[index].localPosition.x > enemyPidgey.transform.localPosition.x && enemyPidgey.currentDirection != 1)
        {
            enemyPidgey.ChangeDirection();
        }

        if (Vector2.Distance(enemyPidgey.transform.position, enemyPidgey.pointsToMove[index].position) < 0.2f)
        {
            index++;

            if (index >= enemyPidgey.pointsToMove.Length)
            {
                index = 0;
            }
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
