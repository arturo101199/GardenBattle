using UnityEngine;

public class SetNextEnemyBase : BNode
{
    public override NodeState Evaluate()
    {
        return NodeState.SUCCESS;
    }

    public override void OnTreeEnded()
    {
        
    }
}