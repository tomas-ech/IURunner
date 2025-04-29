using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Stats")]
    public float speed = 10f;

    #region Components
    public Animator animator {  get; private set; }
    public Rigidbody2D rigidBody {  get; private set; }
    #endregion
    #region States
    public PlayerStateMachine stateMachine {  get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    #endregion

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
    }

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        stateMachine.Initialize(idleState);
    }

    private void Update()
    {
        stateMachine.currentState.Update();
    }

    public void SetMovement(float horizontalVelocity, float verticalVelocity)
    {
        rigidBody.velocity  = new Vector2(horizontalVelocity, verticalVelocity);
    }
}
