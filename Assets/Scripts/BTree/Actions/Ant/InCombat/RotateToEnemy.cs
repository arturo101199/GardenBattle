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
            calculateDirectionAndRotationToLook();
            isRotating = true;
        }
        else if (Vector3.Dot(agent.transform.forward, directionToEnemy) > 0.995f)
        {
            return NodeState.SUCCESS;
        }
        agent.transform.rotation = Quaternion.RotateTowards(agent.transform.rotation, lookRotation, Time.deltaTime * agent.angularSpeed);
        return NodeState.RUNNING;
    }

    public override void OnTreeEnded()
    {
        isRotating = false;
    }

    private void calculateDirectionAndRotationToLook()
    {
        Transform enemy = (Transform)blackboard.GetValue("currentEnemy");
        directionToEnemy = Vector3Utilities.GetDirectionXZFromTo(transform.position, enemy.position);
        lookRotation = Quaternion.LookRotation(directionToEnemy);
    }
}