using UnityEngine;

public class AntImFarFromMyBase : BNode
{
    float distance = 3.5f;

    public override NodeState Evaluate()
    {
        Vector3 baseLocation = (Vector3)AntGlobalBlackboard.Instance.GetValue("baseLocation");
        if(Vector3.Distance(transform.position, baseLocation) >= distance)
        {
            return NodeState.SUCCESS;
        }
        return NodeState.FAIL;
    }

    public override void OnTreeEnded()
    {
    }
}
