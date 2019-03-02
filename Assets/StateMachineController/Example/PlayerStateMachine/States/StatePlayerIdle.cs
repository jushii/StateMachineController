using UnityEngine;

public class StatePlayerIdle : State
{
    private Player player;

    public StatePlayerIdle(StateMachine stateMachine, Player player)
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

        // If we register movement from the player, let's change the state to StatePlayerWalking.
        if (moveAxis != Vector3.zero)
        {
            this.StateMachine.ChangeState(typeof(StatePlayerWalking), moveAxis);
        }
    }
}