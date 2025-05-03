using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : Enemy
{
    [Header("Stats")]
    [SerializeField] private float speed;

    [SerializeField] private Transform[] pointsToMove;

    private int index;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, pointsToMove[index].position, speed * Time.deltaTime);

        if (pointsToMove[index].localPosition.x <= transform.localPosition.x && isForward)
        {
            ChangeDirection();
        } else if (pointsToMove[index].localPosition.x > transform.localPosition.x && !isForward)
        {
            ChangeDirection();
        }

            if (Vector2.Distance(transform.position, pointsToMove[index].position) < 0.2f)
        {
            index++;

            if (index >= pointsToMove.Length)
            {
                index = 0;
            }
        }
    }
}
