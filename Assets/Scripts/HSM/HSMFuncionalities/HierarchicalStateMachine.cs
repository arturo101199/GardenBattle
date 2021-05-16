using UnityEngine;

public class HierarchicalStateMachine : MonoBehaviour, IParentState
{
    [SerializeField] protected StateSelector initialStateSelector;
    [SerializeField] protected Transition[] transitions;
    [SerializeField] AIHandlerHSMs AIHandlerHSMs = null;

    State activeState;

    public void SetCurrentState(State state)
    {
        activeState = state;
    }

    private void Start()
    {
        activeState = initialStateSelector.SelectNode();
        activeState.OnStateEnter();
        activeState.SetParentState(this);
        AIHandlerHSMs.AddMachine(this);
    }

    public void UpdateMachine()
    {
        foreach (Transition transition in transitions)
        {
            if (transition.isTriggered() && transition.TargetNode != activeState)
            {
                transition.MakeHierachicalStateMachineTransition(this, activeState);
                return;
            }
        }
        activeState.OnStateUpdate();
    }

    private void OnDestroy()
    {
        AIHandlerHSMs.RemoveMachine(this);
    }
}
