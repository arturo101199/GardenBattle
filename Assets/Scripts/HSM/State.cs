using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] protected Transition[] transitions;

    public abstract void OnStateEnter();
    public abstract void OnStateExit();
    public abstract void OnStateUpdate();
}
