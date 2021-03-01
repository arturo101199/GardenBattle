using UnityEngine;

public enum NodeState { FAIL = 0, RUNNING = 1, SUCCESS = 2 }

public class BTree : MonoBehaviour
{
    [SerializeField] BNode initialNode = null;
    BNode[] allNodes = new BNode[] { };

    private void Awake()
    {
        allNodes = GetComponentsInChildren<BNode>();
    }

    public NodeState EvaluateTree()
    {
        NodeState state = initialNode.Evaluate();
        if (state != NodeState.RUNNING) resetNodes();
        return state;
    }

    void resetNodes()
    {
        foreach (BNode node in allNodes)
        {
            node.OnTreeEnded();
        }
    }
}