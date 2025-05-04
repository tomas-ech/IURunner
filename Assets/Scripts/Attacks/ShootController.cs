using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private int speed = 2;
    [SerializeField] private Rigidbody2D rigidbody;

    private void Update()
    {
        rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out var player))
        {
            player.ReceiveDamage(damage);
            Destroy(gameObject);
        }

    }

}
