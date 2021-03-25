using UnityEngine;

public class CheckIfMyBaseIsInDanger : BNode
{
    [SerializeField] bool desiredBool = true;
    GlobalBlackboard globalBlackboard;

    private void Start()
    {
        globalBlackboard = (GlobalBlackboard)blackboard.GetValue("globalBlackboard");
    }

    public override NodeState Evaluate()
    {
        if ((bool)globalBlackboard.GetValue("baseIsInDanger") == desiredBool) return NodeState.SUCCESS;
        else return NodeState.FAIL;
    }

    public override void OnTreeEnded()
    {
        
    }
}