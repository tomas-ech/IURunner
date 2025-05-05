using UnityEngine;

public class EnemyPidgey : Enemy
{
    [Header("Pidgey Stats")]
    public float moveTime = 2f;

    public Transform[] pointsToMove;

    #region States
    public PidgeyIdleState idleState { get; private set; }
    public PidgeyMoveState moveState { get; private set; }
    #endregion


    protected override void Awake()
    {
        base.Awake();

        idleState = new PidgeyIdleState(stateMachine, this, "Idle", this);
        moveState = new PidgeyMoveState(stateMachine, this, "Move", this);
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

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

}
