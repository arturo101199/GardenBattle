using UnityEngine;

public class IAmInLowHealth : BNode
{
    [SerializeField] bool isLowLife = false;

    public override NodeState Evaluate()
    {
        if (isLowLife) return NodeState.SUCCESS;
        else return NodeState.FAIL;
    }

    public override void OnTreeEnded()
    {
        
    }
}