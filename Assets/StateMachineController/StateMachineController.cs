namespace SMC
{
    using System.Collections.Generic;

    /// <summary>
    /// StateMachineController holds a reference to all MasterStateMachines and is
    /// responsible of running their Update(), FixedUpdate() and LateUpdate() methods. 
    /// </summary>
    public class StateMachineController
    {
        private List<MasterStateMachine> masterStateMachines = null;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public StateMachineController()
        {
            this.masterStateMachines = new List<MasterStateMachine>();
        }

        internal void AddMasterStateMachine(MasterStateMachine masterStateMachine)
        {
            this.masterStateMachines.Add(masterStateMachine);
        }
        
        /// <summary>
        /// Runs Unity's Update() method for each MasterStateMachine.
        /// IMPORTANT: This method must be called from Update()!
        /// </summary>
        internal void Tick()
        {
            for (int i = 0; i < this.masterStateMachines.Count; i++)
            {
                this.masterStateMachines[i].Tick();
            }
        }

        /// <summary>
        /// Runs Unity's FixedUpdate() method for each MasterStateMachine.
        /// IMPORTANT: This method must be called from FixedUpdate()!
        /// </summary>
        internal void FixedTick()
        {
            for (int i = 0; i < this.masterStateMachines.Count; i++)
            {
                this.masterStateMachines[i].FixedTick();
            }
        }

        /// <summary>
        /// Runs Unity's LateUpdate() method for each MasterStateMachine.
        /// IMPORTANT: This method must be called from LateUpdate()!
        /// </summary>
        internal void LateTick()
        {
            for (int i = 0; i < this.masterStateMachines.Count; i++)
            {
                this.masterStateMachines[i].LateTick();
            }
        }
    }
}