using UnityEngine;

public class IAmInLowHealth : BNode
{
    [SerializeField] bool desiredBool = true;
    public override NodeState Evaluate()
    {
        if ((float)blackboard.GetValue("health") <= 40f == desiredBool) return NodeState.SUCCESS;
        else return NodeState.FAIL;
    }

    public override void OnTreeEnded()
    {
        
    }
}