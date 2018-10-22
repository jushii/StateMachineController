namespace SMC
{
    /// <summary>
    /// 
    /// State is controlled by a StateMachine.
    /// 
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
        /// Last method called before exiting the state.
        /// </summary>
        public abstract void ExitState();

        /// <summary>
        /// Runs in Unity's Update()
        /// </summary>
        internal virtual void Tick()
        {
            
        }

        /// <summary>
        /// Runs FixedUpdate()
        /// </summary>
        internal virtual void FixedTick()
        {
            
        }

        /// <summary>
        /// Runs LateUpdate()
        /// </summary>
        internal virtual void LateTick()
        {
            
        }
    }
}