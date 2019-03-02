using System;
using System.Collections.Generic;

public class StateMachine
{
    internal MasterStateMachine masterStateMachine = null;
    internal State CurrentState { get; set; }
    internal State PreviousState { get; set; }
    internal List<State> states = new List<State>();

    public StateMachine(MasterStateMachine masterStateMachine)
    {
        if (masterStateMachine != null)
        {
            this.masterStateMachine = masterStateMachine;
        }
    }

    internal virtual void Begin(Type stateType, object args)
    {
        for (int i = 0; i < this.states.Count; i++)
        {
            if (this.states[i].GetType() == stateType)
            {
                ChangeState(stateType, args);
                return;
            }
        }
    }

    internal virtual void Exit()
    {
        this.CurrentState.ExitState();
    }

    /// <summary>
    /// Run Update.
    /// </summary>
    internal void Tick()
    {
        this.CurrentState?.Tick();
    }

    /// <summary>
    /// Run FixedUpdate.
    /// </summary>
    internal void FixedTick()
    {
        this.CurrentState?.FixedTick();
    }

    /// <summary>
    /// Run LateUpdate.
    /// </summary>
    internal void LateTick()
    {
        this.CurrentState?.LateTick();
    }

    public virtual bool ChangeState(Type state, object args = null)
    {
        // Check if we are trying to transition to the same state we already are in.
        if (this.CurrentState != null && this.CurrentState.GetType() == state)
        {
            return false;
        }

        for (int i = 0; i < this.states.Count; i++)
        {
            // Found the state we want to transition to.
            if (this.states[i].GetType() == state)
            {
                // Exit previous state.
                this.PreviousState = this.CurrentState;
                if (this.PreviousState != null)
                {
                    this.PreviousState.ExitState();
                }

                // Enter the new state.
                this.CurrentState = this.states[i];
                this.CurrentState.EnterState(args);

                return true;
            }

        }

        return false;
    }

    /// <summary>
    /// Changes the active StateMachine.
    /// </summary>
    /// <param name="stateMachineType"></param>
    internal void ChangeStateMachine(Type stateMachineType, Type stateType, object args = null)
    {
        this.masterStateMachine.ChangeStateMachine(stateMachineType, stateType, args);
    }
}
