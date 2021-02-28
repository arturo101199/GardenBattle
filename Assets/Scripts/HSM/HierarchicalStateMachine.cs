using UnityEngine;

public class HierarchicalStateMachine : MonoBehaviour, IParentState
{

    [SerializeField] protected StateSelector initialStateSelector;
    [SerializeField] protected Transition[] transitions;

    [SerializeField] State currentState;

    public void SetCurrentState(State state)
    {
        currentState = state;
    }

    private void Start()
    {
        currentState = initialStateSelector.SelectNode();
        currentState.OnStateEnter();
        currentState.SetParentState(this);
    }

    private void Update()
    {
        foreach (Transition transition in transitions)
        {
            if (transition.isTriggered())
            {
                currentState.OnStateExit();
                currentState = transition.TargetNode;
                currentState.OnStateEnter();
                return;
            }
        }
        currentState.OnStateUpdate();
    }

}
