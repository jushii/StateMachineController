/// <summary>
/// State controlled by a StateMachine.
/// </summary>
public abstract class State
{
    protected StateMachine StateMachine { get; set; }

    protected State(StateMachine stateMachine)
    {
        this.StateMachine = stateMachine;
    }

    /// <summary>
    /// Called before update methods when entering the state.
    /// </summary>
    public abstract void EnterState(object args);

    /// <summary>
    /// Last method called before exiting the state.
    /// </summary>
    public abstract void ExitState();

    /// <summary>
    /// Run Update.
    /// </summary>
    public virtual void Tick() { }

    /// <summary>
    /// Run FixedUpdate.
    /// </summary>
    public virtual void FixedTick() { }

    /// <summary>
    /// Run LateUpdate.
    /// </summary>
    public virtual void LateTick() { }
}