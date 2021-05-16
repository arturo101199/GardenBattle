using UnityEngine;

public enum NodeState { FAIL = 0, RUNNING = 1, SUCCESS = 2 }

public class BTree : MonoBehaviour
{
    [SerializeField] BNode initialNode = null;
    BNode[] allNodes = new BNode[] { };
    Blackboard blackboard;

    private void Awake()
    {
        allNodes = GetComponentsInChildren<BNode>();
        blackboard = GetComponentInParent<Blackboard>();
        setBlackboard();
    }

    void setBlackboard()
    {
        foreach (BNode node in allNodes)
        {
            node.SetBlackboard(blackboard);
        }
    }

    public NodeState EvaluateTree()
    {
        NodeState state = initialNode.Evaluate();
        if (state != NodeState.RUNNING) ResetNodes();
        return state;
    }

    public void ResetNodes()
    {
        foreach (BNode node in allNodes)
        {
            node.OnTreeEnded();
        }
    }
}