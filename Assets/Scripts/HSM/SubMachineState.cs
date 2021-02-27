using UnityEngine;

public abstract class SubMachineState : State
{
    protected State currentState;

    [SerializeField] protected StateSelector initialStateSelector;

    public void SetCurrentState(State state)
    {
        currentState = state;
    }
}