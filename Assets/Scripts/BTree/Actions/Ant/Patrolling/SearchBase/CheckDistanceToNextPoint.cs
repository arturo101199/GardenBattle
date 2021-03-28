using UnityEngine;
using UnityEngine.AI;

public class CheckDistanceToNextPoint : BNode
{
    NavMeshAgent agent;
    Transform rayOrigin;
    LayerMask myLayer;
    float timer = 0f;
    bool colisioned;

    private void Start()
    {
        agent = (NavMeshAgent)blackboard.GetValue("navMeshAgent");
        rayOrigin = GetComponentInChildren<Transform>();
        myLayer = 1 << gameObject.layer;
    }

    public override NodeState Evaluate()
    {
        if (agent.remainingDistance < 1f || agent.remainingDistance == Mathf.Infinity)
        {
            return NodeState.SUCCESS;
        }
        else if (Physics.Raycast(rayOrigin.position, transform.forward, 1.5f, myLayer))
        {
            if(!colisioned)
            {
                colisioned = true;
                timer = 0f;
                return NodeState.SUCCESS;
            }
        }
        if (colisioned)
        {
            timer += Time.deltaTime;
            if (timer >= 2)
            {
                colisioned = false;
                timer = 0f;
            }
        }
        return NodeState.FAIL;
    }

    public override void OnTreeEnded()
    {
        
    }

}