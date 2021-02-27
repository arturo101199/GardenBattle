using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] protected Transition[] transitions;
    protected State parentState;

    public abstract void OnStateEnter();
    public abstract void OnStateExit();
    public abstract void OnStateUpdate();
}
