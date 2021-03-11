using UnityEngine;

public class GoForFood : BNode
{
    public override NodeState Evaluate()
    {
        return NodeState.SUCCESS;
    }

    public override void OnTreeEnded()
    {
        
    }
}