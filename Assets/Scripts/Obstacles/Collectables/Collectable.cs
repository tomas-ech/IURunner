using UnityEngine;

public class Collectable : MonoBehaviour
{
    private int score;

    private void Start()
    {
        score = RandomGenerator.GetRandomInt(5, 10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.TryGetComponent<Player>(out var player))
        {
            AudioManager.instance.PlaySoundEffect(1);
            player.UpdateScore(score);
            Destroy(gameObject);
        }
    }
}
