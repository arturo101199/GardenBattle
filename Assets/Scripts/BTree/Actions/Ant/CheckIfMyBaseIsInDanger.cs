using UnityEngine;

public class CheckIfMyBaseIsInDanger : BNode
{
    [SerializeField] bool desiredBool = true;

    public override NodeState Evaluate()
    {
        if ((bool)AntGlobalBlackboard.Instance.GetValue("baseIsInDanger") == desiredBool) return NodeState.SUCCESS;
        else return NodeState.FAIL;
    }

    public override void OnTreeEnded()
    {
        
    }
}