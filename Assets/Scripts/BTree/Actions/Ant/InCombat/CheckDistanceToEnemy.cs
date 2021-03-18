using UnityEngine;

public class CheckDistanceToEnemy : BNode
{
    float distance = 1.5f;

    public override NodeState Evaluate()
    {
        Transform enemy = (Transform)blackboard.GetValue("currentEnemy");
        if (Vector3.Distance(transform.position, enemy.position) <= distance)
            return NodeState.SUCCESS;
        else
            return NodeState.FAIL;
    }

    public override void OnTreeEnded()
    {

    }
}