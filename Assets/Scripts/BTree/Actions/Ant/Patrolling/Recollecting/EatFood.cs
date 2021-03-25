using UnityEngine;
using UnityEngine.AI;

public class EatFood : BNode
{
    Animator anim;
    float eatAnimationLength = 0f;
    float timer = 0f;
    bool isEating;
    NavMeshAgent agent;
    GlobalBlackboard globalBlackboard;

    private void Start()
    {
        anim = (Animator)blackboard.GetValue("animator");
        agent = (NavMeshAgent)blackboard.GetValue("navMeshAgent");
        eatAnimationLength = AnimatorUtilities.GetClipLength(anim, "Attack");
        globalBlackboard = (GlobalBlackboard)blackboard.GetValue("globalBlackboard");
    }

    public override NodeState Evaluate()
    {
        if ((Vector3)blackboard.GetValue("currentFoodLocation") == Vector3.zero)
            return NodeState.SUCCESS;
        if (isEating)
        {
            if(timer >= eatAnimationLength)
            {
                ObjectDestroyer.DestroyObjectAtGivenPosition((Vector3)blackboard.GetValue("currentFoodLocation"), LayerMask.GetMask("Food"));
                int foodEaten = (int)globalBlackboard.GetValue("foodEaten");
                globalBlackboard.UpdateValue("foodEaten", foodEaten + 1);
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
            isEating = true;
        }
        return NodeState.RUNNING;

    }

    public override void OnTreeEnded()
    {
        timer = 0f;
        isEating = false;
        agent.isStopped = false;
    }
}
