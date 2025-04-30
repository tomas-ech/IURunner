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
        Debug.Log("Entrando a: " + animBoolName);
    }

    public virtual void Update()
    {
        Debug.Log("Actualmente en: " + animBoolName);
        horizontalInput = Input.GetAxisRaw("Horizontal");
        player.animator.SetFloat("VerticalVelocity", player.rigidBody.velocity.y);
    }

    public virtual void Exit()
    {
        player.animator.SetBool(animBoolName, false);
        Debug.Log("Saliendo de: " + animBoolName);
    }
}
