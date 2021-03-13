using UnityEngine;

public class AntPatrolling : SubMachineState
{
    Animator anim;

    protected override void Awake()
    {
        base.Awake();
        anim = (Animator)blackboard.GetValue("animator");
    }

    public override void OnStateEnter()
    {
        anim.SetBool("isMoving", true);
        base.OnStateEnter();
    }

    public override void OnStateExit()
    {
        base.OnStateExit();

    }

    public override void OnStateUpdate()
    {
        base.OnStateUpdate();
    }
}