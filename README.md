# State Machine Controller for Unity
StateMachineController is a modular finite state machine (FSM) controller for Unity.

#### Features
* Modular FSM system
* Pass custom arguments when changing states
* Supports multiple state machines

##### Example 1 - Changing the active state.
```cs
this.StateMachine.ChangeState(typeof(StatePlayerTurn));
```
##### Example 2 - Passing data when changing the state.
```cs
SpellData spellData = new SpellData()
{
   attackPower = 120,
   coolDown = 5
};

this.StateMachine.ChangeState(typeof(StateCastingSpell), spellData);
```
##### Example 3 - Changing the active state machine.
```cs
this.StateMachine.ChangeStateMachine(typeof(BattleModeStateMachine), typeof(StateBattleStart));
```
