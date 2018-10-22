# StateMachineController
StateMachineController is a controller for running multiple state machines (FSM).

## Classes

### StateMachineController
Holds a collection of MasterStateMachines and calls their Update(), FixedUpdate() and LateUpdate() methods.

### MasterStateMachine
MasterStateMachine can hold either one or multiple state machines. It can be seen as a collection of related StateMachines where one StateMachine can be active at a time.
    
For example: in a turn-based game there could be one state machine for EXPLORATION_MODE and one BATTLE_MODE.
A single MasterStateMachine could have a reference to these two state machines - and these two state machines
could call the MasterStateMachine to change the current active StateMachine.
     
### StateMachine
StateMachine holds a collection of different states.

### State
This is where the magic happens.
