using System;
using UnityEngine;

// BaseState demands an Enum as class parameter.
public abstract class BaseState<Estate> where Estate : Enum
{
    public BaseState(Estate key)
    {
        Statekey = key;
    }

    public Estate Statekey { get; private set; }

    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();
    public abstract Estate GetNextState();
    public abstract void OnTriggerEnter2D(Collider2D collision);
    public abstract void OnTriggerStay2D(Collider2D collision);
    public abstract void OnTriggerExit2D(Collider2D collision);

}
