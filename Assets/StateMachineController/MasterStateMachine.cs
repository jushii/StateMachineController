using System;
using System.Collections.Generic;
using UnityEngine;

public class MasterStateMachine
{
    private List<StateMachine> stateMachines = new List<StateMachine>();
    private StateMachine currentStateMachine;
    private StateMachine previousStateMachine;

    /// <summary>
    /// Add a new StateMachine.
    /// </summary>
    /// <param name="stateMachine">StateMachine to add.</param>
    internal void AddStateMachine(StateMachine stateMachine)
    {
        Type stateMachineType = stateMachine.GetType();
        for (int i = 0; i < this.stateMachines.Count; i++)
        {
            if (this.stateMachines[i].GetType() == stateMachineType)
            {
                Debug.LogError("@MasterStateMachine: Trying to add multiple StateMachines of same type.");
                return;
            }
        }

        this.stateMachines.Add(stateMachine);
    }

    internal void InitialiseStartingStateMachine(Type stateMachineType, Type stateType, object args = null)
    {
        for (int i = 0; i < this.stateMachines.Count; i++)
        {
            if (this.stateMachines[i].GetType() == stateMachineType)
            {
                ChangeStateMachine(stateMachineType, stateType, args);
                return;
            }
        }

        Debug.LogError("@MasterStateMachine: Could not initialize starting StateMachine.");
        return;
    }

    /// <summary>
    /// Run Update.
    /// </summary>
    internal void Tick()
    {
        this.currentStateMachine?.Tick();
    }

    /// <summary>
    /// Run FixedUpdate.
    /// </summary>
    internal void FixedTick()
    {
        this.currentStateMachine?.FixedTick();
    }

    /// <summary>
    /// Run LateUpdate.
    /// </summary>
    internal void LateTick()
    {
        this.currentStateMachine?.LateTick();
    }

    /// <summary>
    /// Change the active StateMachine.
    /// </summary>
    /// <param name="stateMachineType">Type of the StateMachine to change to.</param>
    /// <param name="stateType">Type of the State the StateMachine begins to run.</param>
    /// <param name="args">Optional arguments to pass data.</param>
    /// <returns>Returns true if the StateMachine change was successful.</returns>
    internal virtual bool ChangeStateMachine(Type stateMachineType, Type stateType, object args = null)
    {
        // Return if we try to change to the already active StateMachine.
        if (this.currentStateMachine != null && this.currentStateMachine.GetType() == stateMachineType)
        {
            Debug.LogWarning("@MasterStateMachine: Trying to change to StateMachine of type: " + stateMachineType + " but it's already the active StateMachine.");
            return false;
        }

        // Find the statemachine by type.
        for (int i = 0; i < this.stateMachines.Count; i++)
        {
            if (this.stateMachines[i].GetType() == stateMachineType)
            {
                // Exit previous StateMachine.
                this.previousStateMachine = this.currentStateMachine;
                if (this.previousStateMachine != null)
                {
                    this.previousStateMachine.Exit();
                }

                // Enter next StateMachine.
                this.currentStateMachine = this.stateMachines[i];
                this.currentStateMachine.ChangeState(stateType, args);
                return true;
            }
        }

        Debug.LogWarning("@MasterStateMachine: Can't find StateMachine of type: " + stateMachineType);
        return false;
    }
}