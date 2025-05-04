using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyVulpix : Enemy
{
    [Header("Vulpix Stats")]
    public float attackTime = 2;


    [SerializeField] private LayerMask playerMask;
    [SerializeField] private GameObject attackPrefab;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private int attackDirection = 1;

    #region States
    public VulpixIdleState idleState { get; private set; }
    public VulpixAttackState attackState { get; private set; }
    #endregion

    protected override void Awake()
    {
        base.Awake();

        idleState = new VulpixIdleState(stateMachine, this, "Idle", this);
        attackState = new VulpixAttackState(stateMachine, this, "Attack", this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
        transform.Rotate(0, 180 * attackDirection, 0);
    }

    protected override void Update()
    {
        base.Update();
    }

    public RaycastHit2D IsPlayerDetected()
    {
       return Physics2D.Raycast(wallChecker.position, Vector2.right * attackDirection, wallDistance, playerMask);
    }

    public void ShootAttack()
    {
        GameObject shoot = Instantiate(attackPrefab, attackPoint.position, Quaternion.identity);
        shoot.GetComponent<ShootController>().InitializeShoot(attackDirection);
        AudioManager.instance.PlaySoundEffect(2);
    }
}
