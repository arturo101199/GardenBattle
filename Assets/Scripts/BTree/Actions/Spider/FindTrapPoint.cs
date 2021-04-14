using UnityEngine;

public class FindTrapPoint : BNode
{
    SpiderWebsManagement spiderWebsManagement;

    private void Start()
    {
        spiderWebsManagement = (SpiderWebsManagement)SpiderGlobalBlackboard.Instance.GetValue("spiderWebsManagement");
    }

    public override NodeState Evaluate()
    {
        Vector3 currentTrapPoint = (Vector3)blackboard.GetValue("currentTrapPointLocation");
        if (!spiderWebsManagement.CheckIfPointIsUsed(currentTrapPoint) && currentTrapPoint != Vector3.zero)
            return NodeState.SUCCESS;
        Vector3 nextTrapPoint = spiderWebsManagement.GetSpiderWebPosition();
        blackboard.UpdateValue("currentTrapPointLocation", nextTrapPoint);
        if (nextTrapPoint == Vector3.zero)
            return NodeState.FAIL;
        return NodeState.SUCCESS;
    }

    public override void OnTreeEnded()
    {

    }
}