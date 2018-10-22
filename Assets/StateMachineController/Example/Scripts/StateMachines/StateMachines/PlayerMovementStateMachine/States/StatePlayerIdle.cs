using SMC;
using UnityEngine;

public class StatePlayerIdle : State
{    
    public StatePlayerIdle(StateMachine stateMachine)
        : base(stateMachine)
    {
    }

    public override void EnterState<T>(T message)
    {     
    }

    public override void ExitState()
    {
    }

    internal override void Tick()
    {
        Vector3 moveAxis = GetMoveAxis();
        if (moveAxis != Vector3.zero)
        {
            this.StateMachine.ChangeState((int)PlayerState.WALKING, (object)null);
        }
    }

    private Vector3 GetMoveAxis()
    {
        float xDelta = Input.GetAxisRaw("Horizontal");
        float zDelta = Input.GetAxisRaw("Vertical");
        return new Vector3(xDelta, 0, zDelta);
    }
}