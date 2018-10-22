using UnityEngine;

namespace SMC
{
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// MasterStateMachine can hold either a single or multiple state machines.
    ///
    /// EXAMPLE - A turn-based game: 
    /// For example: in a turn-based game there could be one state machine for EXPLORATION_MODE and one BATTLE_MODE.
    /// A single MasterStateMachine could have a reference to these two state machines.
    ///
    /// Example scenario for changing state machines:
    /// 
    ///     EXPLORATION_MODE StateMachine is currently active.
    ///         -> Battle with enemy is triggered! Call ChangeStateMachine(BATTLE_MODE) to change the StateMachine;
    ///     BATTLE_MODE StateMachine is currently active.
    ///         -> Battle is won! Call ChangeStateMachine(EXPLORATION_MODE) to change back to EXPLORATION_MODE StateMachine;
    ///     EXPLORATION_MODE StateMachine is currently active. 
    /// 
    /// </summary>

    public class MasterStateMachine
    {
        internal Dictionary<StateMachineType, StateMachine> stateMachines;

        private StateMachine currentStateMachine = null;
        private StateMachine previousStateMachine = null;

        public MasterStateMachine()
        {
            this.stateMachines = new Dictionary<StateMachineType, StateMachine>();
        }

        internal void AddStateMachine(StateMachineType stateMachineType, StateMachine stateMachine)
        {
            this.stateMachines.Add(stateMachineType, stateMachine);
        }
        
        internal void SetStartingStateMachine(StateMachine stateMachine)
        {
            this.currentStateMachine = stateMachine;
        }

        internal void Tick()
        {
            if (this.currentStateMachine == null)
            {
                return;
            }

            this.currentStateMachine.Tick();
        }

        internal void FixedTick()
        {
            if (this.currentStateMachine == null)
            {
                return;
            }

            this.currentStateMachine.FixedTick();
        }

        internal void LateTick()
        {
            if (this.currentStateMachine == null)
            {
                return;
            }

            this.currentStateMachine.LateTick();
        }

        public virtual bool ChangeStateMachine(StateMachineType stateMachineType)
        {
            if (!this.stateMachines.ContainsKey(stateMachineType))
            {
                Debug.LogError("@MasterStateMachine: MasterStateMachine doesn't contain  a StateMachine called: " + stateMachineType.ToString());
                return false;
            }

            if (this.stateMachines[stateMachineType] == this.currentStateMachine)
            {
                Debug.LogError("@MasterStateMachine: StateMachine " + stateMachineType.ToString() + " is already active.");
                return false;
            }

            this.previousStateMachine = this.currentStateMachine;
            if (this.previousStateMachine != null)
            {
                this.previousStateMachine.Exit();
            }

            this.currentStateMachine = this.stateMachines[stateMachineType];
            this.currentStateMachine.Begin();

            return true;
        }
    }
}