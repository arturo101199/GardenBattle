using UnityEngine;

public class AntDie : State
{
    [SerializeField] GameObject parent;
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        Destroy(parent);
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