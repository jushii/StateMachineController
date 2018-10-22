[Readme and repository is work in progress]

# StateMachineController
StateMachineController is a finite state machine (FSM) controller for Unity. Divide your game logic to different state machines and let StateMachineController handle updating them.

Changing a state is simple!

call `this.StateMachine.ChangeState((int)BattleMode.MOVING, (object)null);`

Need to pass custom data to the next state?

call `this.StateMachine.ChangeState((int)BattleMode.END_BATTLE, BattleData);`

To change state machine:

call `this.StateMachine.ChangeStateMachine(StateMachineType.SHOP);`

#### Features
* A single class to run all your state machines
    * StateMachineController runs Update(), FixedUpdate() and LateUpdate() for all your state machines
* MasterStateMachine that can hold multiple state machines
    * Individual state machines can call MasterStateMachine to change the active state machine
    * You can have multiple MasterStateMachines running at the same time!
* Pass your own data to other states when changing states
1) Bundle your custom data in one state
```
// Bundle your custom data
CastSkillMessage msg = new CastSkillMessage();
msg.User = this.user;
msg.Target = this.target;
msg.Skill = this.skill;
// Pass the data to the next state
this.StateMachine.ChangeState((int)BattleModeState.CASTING_SKILL, msg);
```
2) Verify and use your data in the next state
```
public override void EnterState<T>(T message)
{
  CastSkillMessage msg = message as CastSkillMessage;
  if (msg == null)
  {
      Debug.LogError("@StateBattleCastingSkill: EnterState message is null");
      return;
  }

  this.msg = msg;

  this.msg.Skill.Resolve(this.msg.User, this.msg.Target, () => 
  {
      Debug.Log("apply effects");
  });
}
```

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
