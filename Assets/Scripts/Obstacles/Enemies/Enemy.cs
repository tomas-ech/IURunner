using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] protected bool canDoDamage = true;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null || canDoDamage)
        {
            collision.GetComponent<Player>().ReceiveDamage(25);
        }
    }
}
