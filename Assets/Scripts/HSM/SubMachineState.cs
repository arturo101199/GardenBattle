using UnityEngine;

public class SubMachineState : State, IParentState
{
    protected State currentState;

    [SerializeField] protected StateSelector initialStateSelector;

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        currentState = initialStateSelector.SelectNode();
        currentState.OnStateEnter();
        currentState.SetParentState(this);
    }

    public override void OnStateUpdate()
    {
        print("Update de " + name);
        foreach (Transition transition in transitions)
        {
            if (transition.isTriggered())
            {
                OnStateExit();
                parentState.SetCurrentState(transition.TargetNode);
                currentState = transition.TargetNode;
                currentState.OnStateEnter();
                return;
            }
        }
        currentState.OnStateUpdate();
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
        currentState.OnStateExit();
        

    }


    public void SetCurrentState(State state)
    {
        currentState = state;
    }
}

public interface IParentState
{
    void SetCurrentState(State state);
}