using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Stats")]
    public float speed = 10f;
    public float jumpSpeed = 5f;

    public float Health {  get; private set; }
    public float Experience {  get; private set; }
    public int Score {  get; private set; }

    public Action onStatsChange = null;

    private float currentDirection = 1f;
    private bool isForward = true;

    [Header("Collisions")]
    [SerializeField] private Transform groundCheckerForward;
    [SerializeField] private Transform groundCheckerBack;
    [SerializeField] private float checkDistance;
    [SerializeField] private LayerMask groundMask;

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
        Health = 100;
        animator = GetComponentInChildren<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        stateMachine.Initialize(idleState);
    }

    private void Update()
    {
        if(transform.position.y <= -1.6)
        {
            PlayerDeath();
            Destroy(gameObject);
            return;
        }

        stateMachine.currentState.Update();


        if(Input.GetKeyDown(KeyCode.Q))
        {
            ReceiveDamage(25);
        }
    }

    private void PlayerDeath()
    {
        Health = 0;
        onStatsChange.Invoke();
        rigidBody.velocity = Vector3.zero;
    }

    public void ReceiveDamage(int damage)
    {
        if (Health > 0)
        {
            Health -= damage;
            onStatsChange.Invoke();
        }
    }

    public void SetMovement(float horizontalVelocity, float verticalVelocity)
    {
        rigidBody.velocity  = new Vector2(horizontalVelocity, verticalVelocity);

        if (horizontalVelocity > 0 && !isForward)
        {
            ChangeDirection();
        }
        else if (horizontalVelocity < 0 && isForward)
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        currentDirection *= -1;
        isForward = !isForward;
        animator.gameObject.transform.Rotate(0, 180, 0);

    }

    public bool IsOnGround()
    {
        bool isGroundF = Physics2D.Raycast(groundCheckerForward.position, Vector2.down, checkDistance, groundMask);
        bool isGroundB = Physics2D.Raycast(groundCheckerBack.position, Vector2.down, checkDistance, groundMask);
        return isGroundF || isGroundB;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheckerForward.position, new Vector3(groundCheckerForward.position.x, groundCheckerForward.position.y - checkDistance));
        Gizmos.DrawLine(groundCheckerBack.position, new Vector3(groundCheckerBack.position.x, groundCheckerBack.position.y - checkDistance));
    }
}
