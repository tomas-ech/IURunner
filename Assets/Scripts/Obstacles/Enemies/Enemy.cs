using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private int damage = 25;

    [SerializeField] protected bool canDoDamage = true;
    [SerializeField] protected Animator animator;

    protected bool isForward = true;

    protected void DoDamage(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null || canDoDamage)
        {
            collision.GetComponent<Player>().ReceiveDamage(damage);
        }
    }

    protected void ChangeDirection()
    {
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
}
