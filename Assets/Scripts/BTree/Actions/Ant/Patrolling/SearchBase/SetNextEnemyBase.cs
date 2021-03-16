using UnityEngine;

public class SetNextEnemyBase : BNode
{
    public override NodeState Evaluate()
    {
        Vector3 closerBase = (Vector3)blackboard.GetValue("closerEnemyBase");
        AntGlobalBlackboard.Instance.UpdateValue("currentEnemyBase", closerBase);
        AntGlobalBlackboard.Instance.UpdateValue("enemyBaseFound", true);
        return NodeState.SUCCESS;
    }

    public override void OnTreeEnded()
    {
        
    }
}