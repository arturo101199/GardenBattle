using UnityEngine;

public class Selector : BNode
{
    [SerializeField] BNode[] childNodes = new BNode[] { };
    NodeState currentState;
    int currentNodeIndex = 0;

    public override NodeState Evaluate()
    {
        for (int i = currentNodeIndex; i < childNodes.Length; i++)
        {
            currentState = childNodes[i].Evaluate();
            if (currentState == NodeState.SUCCESS)
            {
                return NodeState.SUCCESS;
            }
            else if (currentState == NodeState.RUNNING)
            {
                currentNodeIndex = i;
                return NodeState.RUNNING;
            }
        }
        return NodeState.FAIL;
    }

    public override void OnTreeEnded()
    {
        currentNodeIndex = 0;
    }

}