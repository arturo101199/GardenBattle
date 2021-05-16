using UnityEngine;

public abstract class BNode : MonoBehaviour, INode
{
    protected Blackboard blackboard;

    public abstract NodeState Evaluate();
    public abstract void OnTreeEnded();

    public void SetBlackboard(Blackboard blackboard)
    {
        this.blackboard = blackboard;
    }
}