using UnityEngine;

public class HierarchicalStateMachine : MonoBehaviour
{
    [SerializeField] State initialState;
    State currentState;

    private void Start()
    {
        currentState = initialState;
        currentState.OnStateEnter();
    }

}
