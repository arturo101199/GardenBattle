using UnityEngine;

[System.Serializable]
public class Transition
{
    [SerializeField] State targetNode = null;
    [SerializeField] Condition condition = null;

    public State TargetNode { get => targetNode; }

    public bool isTriggered()
    {
        if(condition != null)
            return condition.EvaluateCondition();
        return false;
    }

    public void MakeStateTransition(State currentState, IParentState parentState)
    {
        MakeBaseTransition(currentState, parentState);
    }

    public void MakeSubMachineStateTransition(SubMachineState currentState, IParentState parentState)
    {
        MakeBaseTransition(currentState, parentState);
        currentState.SetCurrentState(targetNode);
    }
    public void MakeHierachicalStateMachineTransition(HierarchicalStateMachine currentState, State activeState)
    {
        activeState.OnStateExit();
        currentState.SetCurrentState(targetNode);
        targetNode.OnStateEnter();
    }

    void MakeBaseTransition(State currentState, IParentState parentState)
    {
        currentState.OnStateExit();
        parentState.SetCurrentState(targetNode);
        targetNode.SetParentState(parentState);
        targetNode.OnStateEnter();
    }
}