using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockEnemy : Enemy
{
    [SerializeField] private float attackDuration = 5f;

    private void Start()
    {
        StartCoroutine(nameof(ActiveAttackState));
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    private IEnumerator ActiveAttackState()
    {
        while (true)
        {
            yield return new WaitForSeconds(RandomGenerator.GetRandomInt(2, 6));

            ChangeAnimation("isAttacking", true);
            canDoDamage = true;

            yield return new WaitForSeconds(attackDuration);

            ChangeAnimation("isAttacking", false);
            canDoDamage = false;
        }
    }
}
