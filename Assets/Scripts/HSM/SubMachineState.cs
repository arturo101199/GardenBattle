using UnityEngine;

public class SubMachineState : State, IParentState
{
    protected State activeState;

    [SerializeField] protected StateSelector initialStateSelector;

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        activeState = initialStateSelector.SelectNode();
        activeState.OnStateEnter();
        activeState.SetParentState(this);
    }

    public override void OnStateUpdate()
    {
        print("Update de " + name);
        checkTransitions();
        activeState.OnStateUpdate();
    }

    protected override void checkTransitions()
    {
        foreach (Transition transition in transitions)
        {
            if (transition.isTriggered())
            {
                transition.MakeSubMachineStateTransition(this, parentState);
                return;
            }
        }
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
        activeState.OnStateExit();
    }

    public void SetCurrentState(State state)
    {
        activeState = state;
    }
}

public interface IParentState
{
    void SetCurrentState(State state);
}