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
        print(agent.isStopped);
        if (!isRotating)
        {
            agent.isStopped = true;
            calculateDirectionAndRotationToLook();
            print(transform.position);
            print(directionToEnemy);
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

    private void calculateDirectionAndRotationToLook()
    {
        Transform enemy = (Transform)blackboard.GetValue("currentEnemy");
        directionToEnemy = Vector3Utilities.GetDirectionXZFromTo(transform.position, enemy.position);
        lookRotation = Quaternion.LookRotation(directionToEnemy);
    }
}