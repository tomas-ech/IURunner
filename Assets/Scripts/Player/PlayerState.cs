using UnityEngine;


public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;

    protected float horizontalInput;
    private string animBoolName;

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        player.animator.SetBool(animBoolName, true);
    }

    public virtual void Update()
    {
        if (player.Health > 0)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
        }
        player.animator.SetFloat("VerticalVelocity", player.rigidBody.velocity.y);
    }

    public virtual void Exit()
    {
        player.animator.SetBool(animBoolName, false);
    }
}
