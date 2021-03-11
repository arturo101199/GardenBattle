using UnityEngine;

public class CheckFood : BNode
{
    public override NodeState Evaluate()
    {
        if((Vector3)blackboard.GetValue("currentFoodLocation") != Vector3.zero)
            return NodeState.SUCCESS;
        return NodeState.FAIL;
    }

    public override void OnTreeEnded()
    {
        
    }
}