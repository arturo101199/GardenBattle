using UnityEngine;

public class MyBaseIsInDanger : BNode
{
    [SerializeField] bool isBaseInDanger = false;

    public override NodeState Evaluate()
    {
        if (isBaseInDanger) return NodeState.SUCCESS;
        else return NodeState.FAIL;
    }

    public override void OnTreeEnded()
    {
        
    }
}