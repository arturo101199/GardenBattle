using UnityEngine;
using UnityEngine.AI;

public class SetTrap : BNode
{
    Animator anim;
    float attackAnimationLength = 0f;
    float timer = 0f;
    bool isSettingTrap;
    NavMeshAgent agent;
    ObjectPooler objectPooler;
    Vector3 currentTrapPos;
    SpiderWebsManagement spiderWebsManagement;
    LayerMask groundLayerMask;

    private void Start()
    {
        anim = (Animator)blackboard.GetValue("animator");
        agent = (NavMeshAgent)blackboard.GetValue("navMeshAgent");
        attackAnimationLength = AnimatorUtilities.GetClipLength(anim, "Attack");
        objectPooler = ObjectPooler.GetInstance();
        spiderWebsManagement = (SpiderWebsManagement)SpiderGlobalBlackboard.Instance.GetValue("spiderWebsManagement");
        groundLayerMask = LayerMask.GetMask("Ground");
    }

    public override NodeState Evaluate()
    {
        currentTrapPos = (Vector3)blackboard.GetValue("currentTrapPointLocation");
        if (currentTrapPos == Vector3.zero || currentTrapPos != agent.destination)
            return NodeState.FAIL;
        if (isSettingTrap)
        {
            if (timer >= attackAnimationLength)
            {
                GameObject spiderWeb = objectPooler.SpawnObject("SpiderWeb", currentTrapPos);
                TransformUtilities.RotateObjectPerpendicularToTheGround(spiderWeb.transform, groundLayerMask);
                spiderWebsManagement.SetPointAsUsed(currentTrapPos);
                return NodeState.SUCCESS;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
        else
        {
            anim.SetTrigger("Attack");
            agent.isStopped = true;
            isSettingTrap = true;
        }
        return NodeState.RUNNING;

    }

    public override void OnTreeEnded()
    {
        timer = 0f;
        isSettingTrap = false;
        agent.isStopped = false;
    }
}
