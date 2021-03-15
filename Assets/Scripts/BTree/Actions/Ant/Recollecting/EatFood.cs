using UnityEngine;
using UnityEngine.AI;

public class EatFood : BNode
{
    Animator anim;
    float eatAnimationLength = 0f;
    float timer = 0f;
    bool isEating;
    NavMeshAgent agent;

    private void Start()
    {
        anim = (Animator)blackboard.GetValue("animator");
        agent = (NavMeshAgent)blackboard.GetValue("navMeshAgent");
        eatAnimationLength = findEatClipLength();
    }

    public override NodeState Evaluate()
    {
        if (isEating)
        {
            if(timer >= eatAnimationLength)
            {
                ObjectDestroyer.DestroyObjectAtGivenPosition((Vector3)blackboard.GetValue("currentFoodLocation"), LayerMask.GetMask("Food"));
                int foodEaten = (int)AntGlobalBlackboard.Instance.GetValue("foodEaten");
                AntGlobalBlackboard.Instance.UpdateValue("foodEaten", foodEaten + 1);
                print("Food eaten");
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

    float findEatClipLength()
    {
        AnimationClip[] animationClips = anim.runtimeAnimatorController.animationClips;

        foreach (AnimationClip clip in animationClips)
        {
            if (clip.name == "Armature_Attack3")
                return clip.length;
        }
        return 0f;
    }

    public override void OnTreeEnded()
    {
        timer = 0f;
        isEating = false;
        agent.isStopped = false;
    }
}
