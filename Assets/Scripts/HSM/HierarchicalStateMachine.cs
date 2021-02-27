using UnityEngine;

public class HierarchicalStateMachine : MonoBehaviour
{

    [SerializeField] protected StateSelector initialStateSelector;
    [SerializeField] protected Transition[] transitions;

    [SerializeField] State currentState;

    private void Start()
    {
        currentState = initialStateSelector.SelectNode();
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
