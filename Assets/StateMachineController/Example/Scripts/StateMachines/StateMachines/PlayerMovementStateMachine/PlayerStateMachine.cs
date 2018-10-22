using SMC;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    private readonly GameUI gameUI = null;
    private readonly Player player = null;
    
    /// <summary>
    /// StateMachine constructor can be extended with additional parameters.
    /// For PlayerStateMachine we include a reference to Player and GameUI.
    /// TIP: You can omit these kind of references if you prefer to use singletons / static classes.
    /// </summary>
    public PlayerStateMachine(MasterStateMachine masterStateMachine, GameUI gameUI, Player player)
        : base(masterStateMachine)
    {
        this.gameUI = gameUI;
        this.player = player;
        
        InitialiseStates();
    }

    internal sealed override void InitialiseStates()
    {
        base.InitialiseStates();
        
        this.States.Add((int) PlayerState.IDLE, new StatePlayerIdle(this));
        this.States.Add((int) PlayerState.WALKING, new StatePlayerWalking(this, this.player));
        this.States.Add((int) PlayerState.JUMPING, new StatePlayerJumping(this, this.player));
        
        Begin();
    }

    internal override void Begin()
    {
        this.ChangeState((int)PlayerState.IDLE, (object)null);
    }
    
    internal override bool ChangeState<T>(int state, T message)
    {
        if (base.ChangeState(state, message))
        {
            this.gameUI.SetPlayerStateMachineLabel("PlayerStateMachine: " + this.CurrentState.ToString());
            return true;
        }

        return false;
    }
}