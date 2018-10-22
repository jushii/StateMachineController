namespace SMC
{
    /// <summary>
    /// State is controlled by a StateMachine.
    /// </summary>
    public abstract class State
    {
        protected StateMachine StateMachine { get; set; }

        protected State(StateMachine stateMachine)
        {
            this.StateMachine = stateMachine;
        }

        /// <summary>
        /// EnterState is called when entering a state.
        /// </summary>
        public abstract void EnterState<T>(T message);

        /// <summary>
        /// ExitState is called before exiting the state.
        /// </summary>
        public abstract void ExitState();

        /// <summary>
        /// Runs Unity's Update() method.
        /// IMPORTANT: Must be called from StateMachine!
        /// </summary>
        internal virtual void Tick()
        {
            
        }

        /// <summary>
        /// Runs Unity's FixedUpdate() method.
        /// IMPORTANT: Must be called from StateMachine!
        /// </summary>
        internal virtual void FixedTick()
        {
            
        }

        /// <summary>
        /// Runs Unity's LateUpdate() method.
        /// IMPORTANT: Must be called from StateMachine!
        /// </summary>
        internal virtual void LateTick()
        {
            
        }
    }
}