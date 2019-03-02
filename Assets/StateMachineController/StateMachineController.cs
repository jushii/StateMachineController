using System.Collections.Generic;

/// <summary>
/// StateMachineController updates all MasterStateMachines.
/// </summary>
public class StateMachineController
{
    private List<MasterStateMachine> masterStateMachines = null;

    public StateMachineController()
    {
        this.masterStateMachines = new List<MasterStateMachine>();
    }

    // Add a new MasterStateMachine.
    internal void AddMasterStateMachine(MasterStateMachine masterStateMachine)
    {
        this.masterStateMachines.Add(masterStateMachine);
    }

    /// <summary>
    /// Run Update.
    /// </summary>
    internal void Tick()
    {
        for (int i = 0; i < this.masterStateMachines.Count; i++)
        {
            this.masterStateMachines[i].Tick();
        }
    }

    /// <summary>
    /// Run FixedUpdate.
    /// </summary>
    internal void FixedTick()
    {
        for (int i = 0; i < this.masterStateMachines.Count; i++)
        {
            this.masterStateMachines[i].FixedTick();
        }
    }

    /// <summary>
    /// Run LateUpdate.
    /// </summary>
    internal void LateTick()
    {
        for (int i = 0; i < this.masterStateMachines.Count; i++)
        {
            this.masterStateMachines[i].LateTick();
        }
    }
}