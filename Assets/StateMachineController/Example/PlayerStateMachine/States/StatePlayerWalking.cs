using UnityEngine;

public class StatePlayerWalking : State
{
    private Player player;

    public StatePlayerWalking(StateMachine stateMachine, Player player)
        : base(stateMachine)
    {
        this.player = player;
    }

    public override void EnterState(object args)
    {
        
    }

    public override void ExitState()
    {
       
    }

    public override void Tick()
    {
        // Get player's move axis.
        Vector3 moveAxis = this.player.GetMoveAxis();

        if (moveAxis != Vector3.zero)
        {
            // Move the player.
            this.player.Move(moveAxis);
        }
        else
        {
            // If we register no movement from the player, let's change the state to StatePlayerIdle.
            this.StateMachine.ChangeState(typeof(StatePlayerIdle), moveAxis);
        }
    }
}