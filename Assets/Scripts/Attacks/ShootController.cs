using System.Collections;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private int speed = 2;
    [SerializeField] private Rigidbody2D rigidbody;

    private int shootDirection = 1;

    private void Start()
    {
        StartCoroutine(nameof(ShootLifeTime));
    }

    private void Update()
    {
        rigidbody.velocity = new Vector2(speed * shootDirection, rigidbody.velocity.y);
    }

    public void InitializeShoot(int direction)
    {
        shootDirection = direction;
        if (direction < 0)
        {
            transform.Rotate(0, 180, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out var player))
        {
            player.ReceiveDamage(damage);
            Destroy(gameObject);
        }
    }

    private IEnumerator ShootLifeTime()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }

}
