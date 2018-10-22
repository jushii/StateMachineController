using UnityEngine;
using SMC;

public class StatePlayerWalking : State
{
    private Player player = null;
    
    /// <summary>
    /// State constructor can be extended with additional parameters.
    /// For StatePlayerWalking we include a reference to player.
    /// </summary>
    public StatePlayerWalking(StateMachine stateMachine, Player player)
        : base(stateMachine)
    {
        this.player = player;
    }

    public override void EnterState<T>(T message)
    {
    }

    public override void ExitState()
    {
    }
    
    internal override void Tick()
    {
        Vector3 moveAxis = GetMoveAxis();
        if (moveAxis != Vector3.zero)
        {
            this.player.Move(moveAxis);
        }
        else
        {
            this.StateMachine.ChangeState((int)PlayerState.IDLE, (object)null);
        }
    }

    private Vector3 GetMoveAxis()
    {
        float xDelta = Input.GetAxisRaw("Horizontal");
        float zDelta = Input.GetAxisRaw("Vertical");
        return new Vector3(xDelta, 0, zDelta);
    }
}