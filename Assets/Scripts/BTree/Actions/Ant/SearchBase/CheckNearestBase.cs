using UnityEngine;

public class CheckNearestBase : BNode
{
    public override NodeState Evaluate()
    {
        return NodeState.SUCCESS;
    }

    public override void OnTreeEnded()
    {
        
    }
}