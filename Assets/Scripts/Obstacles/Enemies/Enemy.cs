using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private int damage = 25;

    [SerializeField] protected bool canDoDamage = true;

    public Animator animator;
    public Rigidbody2D rigidBody;

    [Header("Collisions")]
    [SerializeField] private Transform groundChecker;
    [SerializeField] private float groundDistance;
    [SerializeField] private Transform wallChecker;
    [SerializeField] private float wallDistance;

    [SerializeField] private LayerMask groundMask;

    public EnemyStateMachine stateMachine {  get; private set; }

    protected bool isForward = true;
    private float currentDirection = 1f;

    private void Awake()
    {
        stateMachine = new EnemyStateMachine();
    }

    private void Update()
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

    protected void DoDamage(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null || canDoDamage)
        {
            collision.GetComponent<Player>().ReceiveDamage(damage);
        }
    }

    protected void ChangeDirection()
    {
        currentDirection *= -1;
        isForward = !isForward;
        animator.gameObject.transform.Rotate(0, 180, 0);

    }

    protected void ChangeAnimation(string animBoolName, bool isActive)
    {
        animator.SetBool(animBoolName, isActive);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        DoDamage(collision);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundChecker.position, new Vector3(groundChecker.position.x, groundChecker.position.y - groundDistance));
        Gizmos.DrawLine(wallChecker.position, new Vector3(wallChecker.position.x + wallDistance, wallChecker.position.y));
    }
}
