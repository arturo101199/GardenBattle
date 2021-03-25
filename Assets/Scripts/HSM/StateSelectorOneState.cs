using UnityEngine;

public class StateSelectorOneState : StateSelector
{
    [SerializeField] State initialState;

    public override State SelectNode()
    {
        return initialState;
    }
}
