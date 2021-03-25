using UnityEngine;

public class SetNextEnemyBase : BNode
{
    GlobalBlackboard globalBlackboard;

    private void Start()
    {
        globalBlackboard = (GlobalBlackboard)blackboard.GetValue("globalBlackboard");
    }

    public override NodeState Evaluate()
    {
        Vector3 closerBase = (Vector3)blackboard.GetValue("closerEnemyBase");
        globalBlackboard.UpdateValue("currentEnemyBase", closerBase);
        globalBlackboard.UpdateValue("enemyBaseFound", true);
        return NodeState.SUCCESS;
    }

    public override void OnTreeEnded()
    {
        
    }
}