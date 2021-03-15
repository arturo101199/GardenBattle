using UnityEngine;
using UnityEngine.AI;

public class AntSearchBaseState : State
{
    [SerializeField] BTree actionTree = null;

    BaseManager baseManager;
    NavMeshAgent agent;
    Vector3 baseLocation;

    private void Start()
    {
        baseManager = (BaseManager)GameGlobalBlackboard.Instance.GetValue("baseManager");
        agent = (NavMeshAgent)blackboard.GetValue("navMeshAgent"); 
        baseLocation = (Vector3)AntGlobalBlackboard.Instance.GetValue("baseLocation");
    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        agent.isStopped = false;
        Vector3 basePosition = baseManager.findClosestBase(transform.position, baseLocation);
        blackboard.UpdateValue("closerEnemyBase", basePosition);
        agent.SetDestination(transform.position);
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }

    public override void OnStateUpdate()
    {
        base.OnStateUpdate();
        actionTree.EvaluateTree();
    }
}
