using UnityEngine;
using UnityEngine.AI;

public class CheckFood : BNode
{
    [SerializeField] float distanceToEat = 5f;
    NavMeshAgent agent;
    bool isClose;
    Quaternion lookRotation;
    Vector3 directionToFood;

    private void Start()
    {
        agent = (NavMeshAgent)blackboard.GetValue("navMeshAgent");
    }

    public override NodeState Evaluate()
    {
        if ((Vector3)blackboard.GetValue("currentFoodLocation") == Vector3.zero)
            return NodeState.SUCCESS;
        if (isClose)
        {
            if(Vector3.Dot(agent.transform.forward, directionToFood) > 0.995f)
            {
                return NodeState.SUCCESS;
            }
            agent.transform.rotation = Quaternion.RotateTowards(agent.transform.rotation, lookRotation, Time.deltaTime * agent.angularSpeed);
        }
        else 
        {
            if (agent.remainingDistance <= distanceToEat)
            {
                isClose = true;
                CalculateDirectionAndRotationToLook();
                agent.isStopped = true;
            }
            else
            {
                return NodeState.FAIL;
            }
        }
        return NodeState.RUNNING;
    }

    private void CalculateDirectionAndRotationToLook()
    {
        Vector3 foodLocation = (Vector3)blackboard.GetValue("currentFoodLocation");
        Vector3 agentLocation = agent.transform.position;
        Vector3 foodLocationXZ = new Vector3(foodLocation.x, 0f, foodLocation.z);
        Vector3 agentLocationXZ = new Vector3(agentLocation.x, 0f, agentLocation.z);

        directionToFood = Vector3.Normalize(foodLocationXZ - agentLocationXZ);
        lookRotation = Quaternion.LookRotation(directionToFood);
    }

    public override void OnTreeEnded()
    {
        isClose = false;
    }
}