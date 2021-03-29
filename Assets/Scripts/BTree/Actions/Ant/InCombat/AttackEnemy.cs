using UnityEngine;
using UnityEngine.AI;

public class AttackEnemy : BNode
{
    Animator anim;
    float attackAnimationLength = 0f;
    NavMeshAgent agent;
    bool isAttacking;
    float timer = 0f;
    float attackDamage = 20f;

    GlobalBlackboard globalBlackboard;

    private void Start()
    {
        anim = (Animator)blackboard.GetValue("animator");
        agent = (NavMeshAgent)blackboard.GetValue("navMeshAgent");
        attackAnimationLength = AnimatorUtilities.GetClipLength(anim, "Attack");
        globalBlackboard = (GlobalBlackboard)blackboard.GetValue("globalBlackboard");
        attackDamage = (float)globalBlackboard.GetValue("attackDamage");
    }

    public override NodeState Evaluate()
    {
        if (isAttacking)
        {
            if (timer >= attackAnimationLength)
            {
                Transform enemy = (Transform)blackboard.GetValue("currentEnemy");
                if (enemy == null)
                    return NodeState.SUCCESS;
                enemy.GetComponent<IDamageable>().GetDamage(attackDamage);
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
            isAttacking = true;
        }
        return NodeState.RUNNING;

    }

    public override void OnTreeEnded()
    {
        timer = 0f;
        isAttacking = false;
        agent.isStopped = false;
    }
}