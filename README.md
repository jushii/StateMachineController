[Description is work in progress]

# StateMachineController
StateMachineController is a finite state machine (FSM) controller for Unity.

#### Features
* A single class (StateMachineController) to run all your state machines
    * Runs Update(), FixedUpdate() and LateUpdate() for all your state machines
* MasterStateMachine that can hold multiple state machines
    * Individual state machines can call MasterStateMachine to change the active state machine
* StateMachineController can run multiple MasterStateMachines

* Pass your own data to other states when changing states

`// Create a message`

`CastSkillMessage msg = new CastSkillMessage();`

`msg.User = this.user;`

`msg.Target = this.target;`

`msg.Skill = this.skill;`

`// Pass the message to the next state`

`this.StateMachine.ChangeState((int)BattleModeState.CASTING_SKILL, msg);`

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
