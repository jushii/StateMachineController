using SMC;

public class StatePlayerJumping : State
{
    private Player player = null;
    
    /// <summary>
    /// State constructor can be extended with additional parameters.
    /// For states in PlayerStateMachine we include a reference to Player.
    /// </summary>
    public StatePlayerJumping(StateMachine stateMachine, Player player)
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
}