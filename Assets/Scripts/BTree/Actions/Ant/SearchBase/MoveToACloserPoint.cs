using UnityEngine;

public class MoveToACloserPoint : BNode
{
    public override NodeState Evaluate()
    {
        return NodeState.SUCCESS;
    }

    public override void OnTreeEnded()
    {
        
    }
}