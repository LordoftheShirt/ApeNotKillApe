using System;
using System.Collections.Generic;
using UnityEngine;

// CLASS PURPOSE:
// This abstract class is the one who keeps track of all the states. He is the only one with Monobehaviour.
// Monobehavior: Exists as components upon objects.

// HOW IT WORKS:
// StateManager demands a generic to be passed along as class parameter. the "where" forces this generic to always be an Enum.
// What this list of Enums is, will be brought by the inheritor.

// Example inherited by: GorillaStateMachine. He now also has Monobehavior.
public abstract class StateManager<Estate> : MonoBehaviour where Estate : Enum
{
    protected Dictionary<Estate, BaseState<Estate>> States = new Dictionary<Estate, BaseState<Estate>>();
    protected BaseState<Estate> CurrentState;

    protected bool isTransitionState = false;
    void Start()
    {
        CurrentState.EnterState();
    }

    // Update is called once per frame
    void Update()
    {
        Estate nextStateKey = CurrentState.GetNextState();

        if (!isTransitionState && nextStateKey.Equals(CurrentState.Statekey)) 
        {
            CurrentState.UpdateState();
        } else if (!isTransitionState)
        {
            TransitionToState(nextStateKey);
        }
    }

    public void TransitionToState(Estate stateKey) 
    {
        isTransitionState = true;
        CurrentState.ExitState();
        CurrentState = States[stateKey];
        CurrentState.EnterState();
        isTransitionState = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CurrentState.OnTriggerEnter2D(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        CurrentState.OnTriggerStay2D(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CurrentState.OnTriggerExit2D(collision);
    }
}
