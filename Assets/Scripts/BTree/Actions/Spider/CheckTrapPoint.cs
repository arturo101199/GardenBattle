using UnityEngine;
using UnityEngine.AI;

public class CheckTrapPoint : BNode
{
    [SerializeField] float distanceToSetTrap = 1.75f;
    NavMeshAgent agent;
    bool isClose;
    Quaternion lookRotation;
    Vector3 directionToFood;
    Vector3 currentTrapPos;

    private void Start()
    {
        agent = (NavMeshAgent)blackboard.GetValue("navMeshAgent");
    }

    public override NodeState Evaluate()
    {
        currentTrapPos = (Vector3)blackboard.GetValue("currentTrapPointLocation");
        if (currentTrapPos == Vector3.zero || currentTrapPos != agent.destination)
            return NodeState.FAIL;
        if (isClose)
        {
            if (Vector3.Dot(agent.transform.forward, directionToFood) > 0.995f)
            {
                return NodeState.SUCCESS;
            }
            agent.transform.rotation = Quaternion.RotateTowards(agent.transform.rotation, lookRotation, Time.deltaTime * agent.angularSpeed);
        }
        else
        {
            if (!agent.pathPending && agent.remainingDistance <= distanceToSetTrap)
            {
                isClose = true;
                CalculateDirectionAndRotationToLook();
                agent.isStopped = true;
            }
            else
            {
                return NodeState.RUNNING;
            }
        }
        return NodeState.RUNNING;
    }

    private void CalculateDirectionAndRotationToLook()
    {
        directionToFood = Vector3Utilities.GetDirectionXZFromTo(transform.position, currentTrapPos);
        lookRotation = Quaternion.LookRotation(directionToFood);
    }

    public override void OnTreeEnded()
    {
        isClose = false;
    }
}
