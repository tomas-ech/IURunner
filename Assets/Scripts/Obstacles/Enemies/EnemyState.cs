using UnityEngine;

public class EnemyState
{
    protected EnemyStateMachine stateMachine;
    protected Enemy enemy;

    protected float stateTimer;

    private string animBoolName;

    public EnemyState(EnemyStateMachine _stateMachine, Enemy _enemy, string _animBoolName)
    {
        this.enemy = _enemy;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        enemy.animator.SetBool(animBoolName, true);
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
    }

    public virtual void Exit()
    {
        enemy.animator.SetBool(animBoolName, false);

    }
}
