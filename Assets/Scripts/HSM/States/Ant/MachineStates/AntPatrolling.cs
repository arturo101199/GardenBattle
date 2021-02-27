using UnityEngine;

public class AntPatrolling : SubMachineState
{
    public override void OnStateEnter()
    {
        print("Entro en Patrolling");
        currentState = initialStateSelector.SelectInitialNode();
        currentState.OnStateEnter();
    }

    public override void OnStateExit()
    {
        currentState.OnStateExit();
    }

    public override void OnStateUpdate()
    {
        print("Update Patrolling");
        foreach (Transition transition in transitions)
        {
            if (transition.isTriggered())
            {
                currentState.OnStateExit();
                currentState = transition.TargetNode;
                currentState.OnStateEnter();
                return;
            }
        }
        currentState.OnStateUpdate();
    }
}