using UnityEngine;

public class HierarchicalStateMachine : MonoBehaviour
{

    [SerializeField] protected InitialStateSelector initialStateSelector;
    [SerializeField] protected Transition[] transitions;

    [SerializeField] State currentState;

    private void Start()
    {
        currentState = initialStateSelector.SelectInitialNode();
        currentState.OnStateEnter();
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
