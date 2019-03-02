using UnityEngine;

public class GameController : MonoBehaviour
{
	// Player is assigned in inspector.
	[SerializeField] private Player player;
		
	private StateMachineController stateMachineController = new StateMachineController();

	private void Awake()
	{
		// Create a MasterStateMachine (can contain multiple StateMachines).
		MasterStateMachine masterStateMachine = new MasterStateMachine();

		// Create a PlayerStateMachine and add it to the MasterStateMachine.
		masterStateMachine.AddStateMachine(new PlayerStateMachine(masterStateMachine, this.player));

		// Add the MasterStateMachine to StateMachineController.
		this.stateMachineController.AddMasterStateMachine(masterStateMachine);

		// Set PlayerStateMachine as the active StateMachine and StatePlayerIdle as the active State.
		masterStateMachine.ChangeStateMachine(typeof(PlayerStateMachine), typeof(StatePlayerIdle));
	}

	private void Update () 
	{
		this.stateMachineController.Tick();
	}
	
	private void FixedUpdate () 
	{
		this.stateMachineController.FixedTick();
	}
	
	private void LateUpdate () 
	{
		this.stateMachineController.LateTick();
	}
}
