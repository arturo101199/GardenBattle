using UnityEngine;
using UnityEngine.AI;

public class AttackEnemy : BNode
{
    protected Animator anim;
    protected float attackAnimationLength = 0f;
    protected NavMeshAgent agent;
    protected bool isAttacking;
    protected float timer = 0f;
    protected float attackDamage = 20f;

    GlobalBlackboard globalBlackboard;

    protected void Start()
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
                attack(enemy);
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

    protected virtual void attack(Transform enemy)
    {
        enemy.GetComponent<IDamageable>().GetDamage(attackDamage);
    }

    public override void OnTreeEnded()
    {
        timer = 0f;
        isAttacking = false;
        agent.isStopped = false;
    }
}