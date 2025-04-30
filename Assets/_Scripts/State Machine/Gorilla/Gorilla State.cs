using System.Collections;
using UnityEngine;

public abstract class GorillaState : BaseState<GorillaStateMachine.EGorillaState>
{
    protected GorillaContext Context;

    public GorillaState(GorillaContext context, GorillaStateMachine.EGorillaState stateKey) : base(stateKey)
    {
        Context = context;
    }
}
