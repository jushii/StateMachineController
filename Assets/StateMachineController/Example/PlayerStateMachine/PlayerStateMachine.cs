// This is a simplified demonstration of how to initialize a StateMachine.
public class PlayerStateMachine : StateMachine
{
    // PlayerStateMachine will be used to control player movement, so let's give it reference to Player.
    public PlayerStateMachine(MasterStateMachine masterStateMachine, Player player)
        : base(masterStateMachine)
    {
        // Here let's give the StateMachine some states.
        this.states.Add(new StatePlayerIdle(this, player));
        this.states.Add(new StatePlayerWalking(this, player));
    }
}