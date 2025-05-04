using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.rigidBody.velocity = new Vector2(player.rigidBody.velocity.x, player.jumpSpeed);
        AudioManager.instance.PlaySoundEffect(RandomGenerator.GetRandomInt(3, 4));
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (horizontalInput != 0)
        {
            player.SetMovement(horizontalInput * player.speed, player.rigidBody.velocity.y);
        }


        if (player.IsOnGround() && player.rigidBody.velocity.y == 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
