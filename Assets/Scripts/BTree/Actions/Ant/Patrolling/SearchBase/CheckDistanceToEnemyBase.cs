using UnityEngine;

public class CheckDistanceToEnemyBase : BNode
{
    float distanceToBase = 5f;

    public override NodeState Evaluate()
    {
        Vector3 closerBase = (Vector3)blackboard.GetValue("closerEnemyBase");
        if (Vector3.Distance(transform.position, closerBase) < distanceToBase)
        {
            return NodeState.SUCCESS;
        }
        else
            return NodeState.FAIL;
    }

    public override void OnTreeEnded()
    {
        
    }
}