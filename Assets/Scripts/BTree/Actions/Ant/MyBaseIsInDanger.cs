using UnityEngine;

public class MyBaseIsInDanger : BNode
{
    public override NodeState Evaluate()
    {
        if ((bool)AntGlobalBlackboard.Instance.GetValue("baseIsInDanger")) return NodeState.SUCCESS;
        else return NodeState.FAIL;
    }

    public override void OnTreeEnded()
    {
        
    }
}