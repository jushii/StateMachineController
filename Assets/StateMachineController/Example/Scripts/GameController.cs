using UnityEngine;
using SMC;

public class GameController : MonoBehaviour
{
	[SerializeField] private GameUI gameUI = null;
	[SerializeField] private Player player = null;
		
	private StateMachineController stateMachineController = null;

	private void Awake()
	{
		InitialiseStateMachineController();
	}

	private void InitialiseStateMachineController()
	{
		// Create a StateMachineController.
		this.stateMachineController = new StateMachineController();
		
		// Create a MasterStateMachine.
		MasterStateMachine masterStateMachine = new MasterStateMachine();
		
		// Create a StateMachine for handling player movement.
		StateMachine playerStateMachine = new PlayerStateMachine(masterStateMachine, this.gameUI, this.player);
		masterStateMachine.AddStateMachine(StateMachineType.PLAYER_MOVEMENT, playerStateMachine);
		
		// Set starting StateMachine for the MasterStateMachine.
		masterStateMachine.SetStartingStateMachine(playerStateMachine);
		
		// Add the MasterStateMachine to StateMachineController.
		this.stateMachineController.AddMasterStateMachine(masterStateMachine);
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
