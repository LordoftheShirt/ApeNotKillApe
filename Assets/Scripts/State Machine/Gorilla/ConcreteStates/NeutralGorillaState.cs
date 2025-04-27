using Unity.VisualScripting;
using UnityEngine;

// Family Tree: NeutralGorillaState -> GorillaState -> BaseState<GorillaStateMachine>. GorillaStateMachine<EGorillaState> -> StateMachine *uses EGorillaState Enums* -> Monobehavior
public class NeutralGorillaState : GorillaState
{
    public NeutralGorillaState(GorillaContext context, GorillaStateMachine.EGorillaState estate) : base (context, estate)
    {
        Context = context;
    }

    public override void EnterState() 
    {
        
    }
    public override void ExitState() { }
    public override void UpdateState() 
    {
        // have got to create a singleton input class:
        //if (InputManager.Instance.Scrolling)
        //Context.MyObject.transform.position += new Vector3 (0, 0.1f);
    }
    public override GorillaStateMachine.EGorillaState GetNextState() 
    {
        return Statekey;
    }
    public override void OnTriggerEnter2D(Collider2D collision) { }
    public override void OnTriggerStay2D(Collider2D collision) { }
    public override void OnTriggerExit2D(Collider2D collision) { }
}
