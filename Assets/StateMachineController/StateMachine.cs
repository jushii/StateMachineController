using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// StateMachine updates the current State.
/// </summary>
public class StateMachine
{
    internal State CurrentState { get; set; }
    internal State PreviousState { get; set; }

    protected MasterStateMachine masterStateMachine;
    protected List<State> states = new List<State>();

    public StateMachine(MasterStateMachine masterStateMachine)
    {
        this.masterStateMachine = masterStateMachine;
    }

    /// <summary>
    /// Exit current state.
    /// </summary>
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

    public virtual bool ChangeState(Type stateType, object args = null)
    {
        // Return if we try to change to the already active State.
        if (this.CurrentState != null && this.CurrentState.GetType() == stateType)
        {
            Debug.LogWarning("@StateMachine: Trying to change to State of type: " + stateType + " but it's already the active State.");
            return false;
        }

        // Find the State by type.
        for (int i = 0; i < this.states.Count; i++)
        {
            // Found the state we want to transition to.
            if (this.states[i].GetType() == stateType)
            {
                // Exit previous State.
                this.PreviousState = this.CurrentState;
                if (this.PreviousState != null)
                {
                    this.PreviousState.ExitState();
                }

                // Enter next State.
                this.CurrentState = this.states[i];
                this.CurrentState.EnterState(args);
                return true;
            }
        }

        Debug.LogWarning("@StateMachine: Can't find State of type: " + stateType);
        return false;
    }

    /// <summary>
    /// Change the active StateMachine.
    /// </summary>
    /// <param name="stateMachineType"></param>
    internal void ChangeStateMachine(Type stateMachineType, Type stateType, object args = null)
    {
        this.masterStateMachine.ChangeStateMachine(stateMachineType, stateType, args);
    }
}
