using UnityEngine;

public abstract class SubMachineState : State
{
    protected State currentState;

    [SerializeField] protected InitialStateSelector initialStateSelector;
}