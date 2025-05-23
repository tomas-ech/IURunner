

using UnityEngine;

public class PikachuAttackState : EnemyState
{
    private EnemyPikachu enemyPikachu;

    public PikachuAttackState(EnemyStateMachine _stateMachine, Enemy _enemy, string _animBoolName, EnemyPikachu _enemyPikachu) : base(_stateMachine, _enemy, _animBoolName)
    {
        this.enemyPikachu = _enemyPikachu;
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = enemyPikachu.attackTime;
        enemyPikachu.canDoDamage = true;

        enemyPikachu.rigidBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }
    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
        {
            stateMachine.ChangeState(enemyPikachu.moveState);
        }

        
    }

    public override void Exit()
    {
        base.Exit();
        enemyPikachu.canDoDamage = false;
        enemyPikachu.rigidBody.constraints = RigidbodyConstraints2D.None;
        enemyPikachu.rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
