using UnityEngine;

public class Sequencer : BNode
{
    [SerializeField] BNode[] childNodes = new BNode[] {};
    NodeState currentState;
    int currentNodeIndex = 0;

    public override NodeState Evaluate()
    {
        for (int i = currentNodeIndex; i < childNodes.Length; i++)
        {
            currentState = childNodes[i].Evaluate();
            if (currentState == NodeState.FAIL)
            {
                return NodeState.FAIL;
            }
            else if (currentState == NodeState.RUNNING)
            {
                currentNodeIndex = i;
                return NodeState.RUNNING;
            }
        }
        return NodeState.SUCCESS;
    }

    public override void OnTreeEnded()
    {
        currentNodeIndex = 0;
    }
}