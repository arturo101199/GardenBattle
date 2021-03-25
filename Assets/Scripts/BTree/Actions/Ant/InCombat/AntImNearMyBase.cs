using UnityEngine;

public class AntImNearMyBase : BNode
{
    float distance = 3.5f;
    GlobalBlackboard globalBlackboard;

    private void Start()
    {
        globalBlackboard = (GlobalBlackboard)blackboard.GetValue("globalBlackboard");
    }

    public override NodeState Evaluate()
    {
        Vector3 baseLocation = (Vector3)globalBlackboard.GetValue("baseLocation");
        if(Vector3.Distance(transform.position, baseLocation) <= distance)
        {
            return NodeState.SUCCESS;
        }
        return NodeState.FAIL;
    }

    public override void OnTreeEnded()
    {
    }
}