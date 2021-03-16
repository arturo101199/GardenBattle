using UnityEngine;

public class AntDefendingBase : SubMachineState
{
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        AntGlobalBlackboard.Instance.UpdateValue("antsDefending", (int)AntGlobalBlackboard.Instance.GetValue("antsDefending") + 1);
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