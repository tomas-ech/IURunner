using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    public float speed = 2f;
    public float idleTime = 2f;
    [SerializeField] private int damage = 25;

    public bool canDoDamage = false;
    public Animator animator;
    public Rigidbody2D rigidBody;

    [Header("Collisions")]
    [SerializeField] private Transform groundChecker;
    [SerializeField] private float groundDistance;
    [SerializeField] protected Transform wallChecker;
    [SerializeField] protected float wallDistance;
    [SerializeField] private LayerMask groundMask;

    public EnemyStateMachine stateMachine {  get; private set; }

    protected bool isForward = true;
    [HideInInspector] public float currentDirection = 1f;

    protected virtual void Awake()
    {
        stateMachine = new EnemyStateMachine();
    }

    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        stateMachine.currentState.Update();
    }

    public bool IsOnGround()
    {
        bool isGround = Physics2D.Raycast(groundChecker.position, Vector2.down, groundDistance, groundMask);
        return isGround;
    }
    
    public bool IsAtWall()
    {
        bool isAWall = Physics2D.Raycast(wallChecker.position, Vector2.right * currentDirection, wallDistance, groundMask);
        return isAWall;
    }

    public void SetMovement(float horizontalVelocity, float verticalVelocity)
    {
        rigidBody.velocity = new Vector2(horizontalVelocity, verticalVelocity);

        if (horizontalVelocity > 0 && !isForward)
        {
            ChangeDirection();
        }
        else if (horizontalVelocity < 0 && isForward)
        {
            ChangeDirection();
        }
    }

    public void ChangeDirection()
    {
        currentDirection *= -1;
        isForward = !isForward;
        transform.Rotate(0, 180, 0);

    }

    protected void ChangeAnimation(string animBoolName, bool isActive)
    {
        animator.SetBool(animBoolName, isActive);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundChecker.position, new Vector3(groundChecker.position.x, groundChecker.position.y - groundDistance));
        Gizmos.DrawLine(wallChecker.position, new Vector3(wallChecker.position.x + wallDistance * currentDirection, wallChecker.position.y));
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out var player) && canDoDamage)
        {
            player.ReceiveDamage(damage);
        }

    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out var player) && canDoDamage)
        {
            player.ReceiveDamage(damage);
        }
    }
}
