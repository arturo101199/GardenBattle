using UnityEngine;

public class IAmInLowHealth : BNode
{

    public override NodeState Evaluate()
    {
        if ((float)blackboard.GetValue("health") <= 40f) return NodeState.SUCCESS;
        else return NodeState.FAIL;
    }

    public override void OnTreeEnded()
    {
        
    }
}