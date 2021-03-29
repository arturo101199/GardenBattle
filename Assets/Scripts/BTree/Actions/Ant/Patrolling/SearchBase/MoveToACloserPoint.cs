using UnityEngine;
using UnityEngine.AI;

public class MoveToACloserPoint : BNode
{
    NavMeshAgent agent;
    float distanceToMove = 7f;

    private void Start()
    {
        agent = (NavMeshAgent)blackboard.GetValue("navMeshAgent");
    }

    public override NodeState Evaluate()
    {
        Vector3 basePos = (Vector3)blackboard.GetValue("closerEnemyBase");
        Vector3 directionToBase = (basePos - transform.position).normalized;

        float maxAngle = CalculateMovementMaxAngle();

        for (int i = 0; i < 20; i++)
        {
            if (tryToMove(maxAngle, directionToBase))
                return NodeState.SUCCESS;
        }
        print("I could not move to next point");
        return NodeState.SUCCESS;
    }

    float CalculateMovementMaxAngle()
    {
        float distanceToBase = Vector3.Distance((Vector3)blackboard.GetValue("closerEnemyBase"), transform.position);
        distanceToBase = Mathf.Clamp(distanceToBase, 4f, 50f);
        float t = Mathf.InverseLerp(4f, 75f, distanceToBase);
        float maxAngle = Mathf.Lerp(0f, 180f, t);
        return maxAngle;
    }

    bool tryToMove(float maxAngle, Vector3 directionToBase)
    {
        float angle = Random.Range(-maxAngle / 2, maxAngle / 2);
        Vector3 directionToMove = Quaternion.Euler(0, angle, 0) * directionToBase;
        float myDistanceToMove = distanceToMove;
        Vector3 pointToMove = transform.position + directionToMove * myDistanceToMove;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(pointToMove, out hit, 3f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
            return true;
        }
        return false;
    }

    public override void OnTreeEnded()
    {
        
    }
}