namespace SMC
{
    using System.Collections.Generic;
    using UnityEngine;

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

        /// <summary>
        /// Runs Unity's Update() method for the current active StateMachine.
        /// IMPORTANT: This method must be called from StateMachineController!
        /// </summary>
        internal void Tick()
        {
            if (this.currentStateMachine == null)
            {
                return;
            }

            this.currentStateMachine.Tick();
        }

        /// <summary>
        /// Runs Unity's FixedUpdate() method for the current active StateMachine.
        /// IMPORTANT: This method must be called from StateMachineController!
        /// </summary>
        internal void FixedTick()
        {
            if (this.currentStateMachine == null)
            {
                return;
            }

            this.currentStateMachine.FixedTick();
        }

        /// <summary>
        /// Runs Unity's LateUpdate() method for the current active StateMachine.
        /// IMPORTANT: This method must be called from StateMachineController!
        /// </summary>
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