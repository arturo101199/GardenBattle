using UnityEngine;

public class State : MonoBehaviour
{
    [SerializeField] protected Transition[] transitions;
    protected IParentState parentState;

    public virtual void OnStateEnter()
    {
        print("entro en " + name);
    }
    public virtual void OnStateExit()
    {
        print("salgo de " + name);
        
    }
    public virtual void OnStateUpdate()
    {
        print("update de " + name);
        foreach (Transition transition in transitions)
        {
            if (transition.isTriggered())
            {
                OnStateExit();
                parentState.SetCurrentState(transition.TargetNode);
                transition.TargetNode.SetParentState(parentState);
                return;
            }
        }
    }
    public virtual void SetParentState(IParentState state)
    {
        parentState = state;
    }
}

