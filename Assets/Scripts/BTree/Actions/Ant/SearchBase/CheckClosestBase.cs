using UnityEngine;

public class CheckClosestBase : BNode
{
    BaseManager baseManager;
    Vector3 baseLocation;

    private void Start()
    {
        baseManager = (BaseManager)GameGlobalBlackboard.Instance.GetValue("baseManager");
        baseLocation = (Vector3)AntGlobalBlackboard.Instance.GetValue("baseLocation");
    }

    public override NodeState Evaluate()
    {
        Vector3 basePosition = baseManager.findClosestBase(transform.position, baseLocation);
        blackboard.UpdateValue("closerEnemyBase", basePosition);
        return NodeState.SUCCESS;
    }

    public override void OnTreeEnded()
    {
        
    }
}