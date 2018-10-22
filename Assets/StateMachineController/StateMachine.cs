namespace SMC
{
	using System.Collections.Generic;

	public class StateMachine
	{
		internal State CurrentState { get; set; }
		internal State PreviousState { get; set; }
		
		internal Dictionary<int, State> States { get; set; }

		private readonly MasterStateMachine masterStateMachine = null;
		
		protected StateMachine(MasterStateMachine masterStateMachine)
		{
			this.masterStateMachine = masterStateMachine;
		}

		internal virtual void InitialiseStates()
		{
			this.States = new Dictionary<int, State>();
		}

		internal virtual void Begin()
		{
			
		}

		internal virtual void Exit()
		{
			this.CurrentState.ExitState();
		}

		/// <summary>
		/// Runs Unity's Update() method for the current active state.
		/// IMPORTANT: This method must be called from Update()
		/// </summary>
		internal void Tick()
		{
			if (this.CurrentState == null)
			{
				return;
			}

			this.CurrentState.Tick();
		}

		/// <summary>
		/// Runs Unity's FixedUpdate() method for the current active state.
		/// IMPORTANT: This method must be called from FixedUpdate()
		/// </summary>
		internal void FixedTick()
		{
			if (this.CurrentState == null)
			{
				return;
			}

			this.CurrentState.FixedTick();
		}

		/// <summary>
		/// Runs Unity's LateUpdate() method for the current active state.
		/// IMPORTANT: This method must be called from LateUpdate()
		/// </summary>
		internal void LateTick()
		{
			if (this.CurrentState == null)
			{
				return;
			}

			this.CurrentState.LateTick();
		}

		/// <summary>
		/// Changes the active State.
		/// </summary>
		internal virtual bool ChangeState<T>(int state, T message)
		{
			if (!this.States.ContainsKey(state))
			{
				return false;
			}

			if (this.States[state] == this.CurrentState)
			{
				return false;
			}

			this.PreviousState = this.CurrentState;
			if (this.PreviousState != null)
			{
				this.PreviousState.ExitState();
			}

			this.CurrentState = this.States[state];

			this.CurrentState.EnterState(message);

			return true;
		}

		/// <summary>
		/// Changes the active StateMachine.
		/// </summary>
		/// <param name="stateMachineType"></param>
		internal void ChangeStateMachine(StateMachineType stateMachineType)
		{
			this.masterStateMachine.ChangeStateMachine(stateMachineType);
		}
	}
}