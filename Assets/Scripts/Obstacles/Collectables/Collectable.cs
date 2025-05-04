using System.Collections;
using System.Collections.Generic;
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
        Debug.Log("Triggered");
        
        if (collision.TryGetComponent<Player>(out var player))
        {
            player.UpdateScore(score);
            Destroy(gameObject);
        }
    }
}
