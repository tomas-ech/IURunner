using UnityEngine;

public class EnemyPikachu : Enemy
{
    [Header("Pikachu Stats")]
    public float moveTime = 2f;
    public float attackTime = 3f;

    #region States
    public PikachuIdleState idleState {  get; private set; }
    public PikachuMoveState moveState {  get; private set; }
    public PikachuAttackState attackState {  get; private set; }
    #endregion


    protected override void Awake()
    {
        base.Awake();

        idleState = new PikachuIdleState(stateMachine, this, "Idle", this);
        moveState = new PikachuMoveState(stateMachine, this, "Move", this);
        attackState = new PikachuAttackState(stateMachine, this, "Attack", this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }
}
