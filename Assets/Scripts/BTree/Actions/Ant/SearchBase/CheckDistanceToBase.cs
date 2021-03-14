using UnityEngine;

public class CheckDistanceToBase : BNode
{
    public override NodeState Evaluate()
    {
        return NodeState.SUCCESS;
    }

    public override void OnTreeEnded()
    {
        
    }
}