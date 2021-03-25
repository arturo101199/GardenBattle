using UnityEngine;

public class CheckIfImHealed : BNode
{
    [SerializeField] bool desiredBool = true;

    public override NodeState Evaluate()
    {
        if(((float)blackboard.GetValue("health") > 100f) == desiredBool)
            return NodeState.SUCCESS;
        return NodeState.FAIL;
    }

    public override void OnTreeEnded()
    {
        
    }
}