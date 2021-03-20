using UnityEngine;

public class CheckIfEnemyIsDead : BNode
{

    public override NodeState Evaluate()
    {
        Transform enemy = (Transform)blackboard.GetValue("currentEnemy");
        if (enemy == null)
            return NodeState.SUCCESS;
        else
            return NodeState.FAIL;
    }

    public override void OnTreeEnded()
    {

    }
}