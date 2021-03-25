using UnityEngine;

public class AntDefendingBase : SubMachineState
{
    GlobalBlackboard globalBlackboard;

    private void Start()
    {
        globalBlackboard = (GlobalBlackboard)blackboard.GetValue("globalBlackboard");
    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        globalBlackboard.UpdateValue("antsDefending", (int)globalBlackboard.GetValue("antsDefending") + 1);
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