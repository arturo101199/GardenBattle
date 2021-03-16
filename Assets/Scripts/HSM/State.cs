using UnityEngine;

public class State : MonoBehaviour
{
    [SerializeField] protected Transition[] transitions;
    protected IParentState parentState;
    protected Blackboard blackboard;

    protected virtual void Awake()
    {
        blackboard = GetComponentInParent<Blackboard>();
    }

    public virtual void OnStateEnter()
    {
        print("entro en " + name);
        transform.root.name = name;
    }
    public virtual void OnStateExit()
    {
        print("salgo de " + name);
        
    }
    public virtual void OnStateUpdate()
    {
        //print("update de " + name);
        checkTransitions();
    }

    protected virtual void checkTransitions()
    {
        foreach (Transition transition in transitions)
        {
            if (transition.isTriggered())
            {
                transition.MakeStateTransition(this, parentState);
                return;
            }
        }
    }

    public virtual void SetParentState(IParentState state)
    {
        parentState = state;
    }
}

