using UnityEngine;

public class CheckBaseIsStillAlive : BNode
{
    BaseManager baseManager;

    private void Start()
    {
        baseManager = (BaseManager)GameGlobalBlackboard.Instance.GetValue("baseManager");
    }

    public override NodeState Evaluate()
    {
        if(baseManager.isBaseAlive((Vector3)blackboard.GetValue("closerEnemyBase")))
            return NodeState.SUCCESS;
        return NodeState.FAIL;
    }

    public override void OnTreeEnded()
    {
        
    }
}