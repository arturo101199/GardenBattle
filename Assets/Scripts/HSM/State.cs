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
        print("entro en " + name + " " + transform.root.GetInstanceID());
        transform.root.name = name;
    }
    public virtual void OnStateExit()
    {
        print("salgo de " + name + " " + transform.root.GetInstanceID());
        
    }
    public virtual void OnStateUpdate()
    {
        if (checkTransitions()) return;
        makeUpdate();
    }

    protected virtual bool checkTransitions()
    {
        foreach (Transition transition in transitions)
        {
            if (transition.isTriggered())
            {
                transition.MakeStateTransition(this, parentState);
                return true;
            }
        }
        return false;
    }

    protected virtual void makeUpdate()
    {

    }

    public virtual void SetParentState(IParentState state)
    {
        parentState = state;
    }
}

