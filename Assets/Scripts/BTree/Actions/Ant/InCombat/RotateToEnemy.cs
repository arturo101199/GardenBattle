using UnityEngine;
using UnityEngine.AI;

public class RotateToEnemy : BNode
{
    Vector3 directionToEnemy;
    Quaternion lookRotation;
    NavMeshAgent agent;
    bool isRotating = false;

    private void Start()
    {
        agent = (NavMeshAgent)blackboard.GetValue("navMeshAgent");
    }

    public override NodeState Evaluate()
    {
        if (!isRotating)
        {
            agent.isStopped = true;
            Transform enemy = (Transform)blackboard.GetValue("currentEnemy");
            if (enemy == null)
                return NodeState.FAIL;
            calculateDirectionAndRotationToLook(enemy);
            isRotating = true;
        }
        if (Vector3.Dot(agent.transform.forward, directionToEnemy) > 0.997f)
        {
            return NodeState.SUCCESS;
        }
        agent.transform.rotation = Quaternion.RotateTowards(agent.transform.rotation, lookRotation, Time.deltaTime * agent.angularSpeed);
        return NodeState.RUNNING;
    }

    public override void OnTreeEnded()
    {
        isRotating = false;
        agent.isStopped = false;
    }

    private void calculateDirectionAndRotationToLook(Transform enemy)
    {
        directionToEnemy = Vector3Utilities.GetDirectionXZFromTo(transform.position, enemy.position);
        lookRotation = Quaternion.LookRotation(directionToEnemy);
    }
}