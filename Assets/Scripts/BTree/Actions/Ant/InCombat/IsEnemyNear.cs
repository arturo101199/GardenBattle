using UnityEngine;

public class IsEnemyNear : BNode
{
    [SerializeField] float distance = 1.5f;
    [SerializeField] bool desiredBool = true;

    public override NodeState Evaluate()
    {
        Transform enemy = (Transform)blackboard.GetValue("currentEnemy");
        print("Distance: " + distance);
        print(Vector3.Distance(transform.position, enemy.position));
        if ((Vector3.Distance(transform.position, enemy.position) <= distance) == desiredBool)
            return NodeState.SUCCESS;
        else
            return NodeState.FAIL;
    }

    public override void OnTreeEnded()
    {

    }
}