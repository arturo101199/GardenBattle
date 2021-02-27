using UnityEngine;

public class AntSearchBaseState : State
{
    public override void OnStateEnter()
    {
        print("Entro en search base");
    }

    public override void OnStateExit()
    {
    
    }

    public override void OnStateUpdate()
    {
        print("Update search base");
    }
}